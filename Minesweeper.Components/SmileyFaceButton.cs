using System.Windows.Forms;
using Minesweeper.Resources;
using System.Drawing;
using System;
using System.Threading;

namespace Minesweeper.Components
{
	public class SmileyFaceButton : PictureBox
	{
		private IMineField parentField;

		protected bool RightMouseButtonDown { get; set; }

		protected bool SpecialActionInvoked { get; set; }

		protected Bitmap BackgroundNormal
		{
			get
			{
				return ButtonImagesProvider.ButtonBackgroundNormal;
			}
		}

		protected Bitmap BackgroundPressed
		{
			get
			{
				return ButtonImagesProvider.ButtonBackgroundPressed;
			}
		}

		protected Bitmap SmileyStandard { get; set; }

		protected Bitmap SmileyOnPress { get; set; }

		protected Bitmap SmileyOnWin { get; set; }

		protected Bitmap SmileyOnLose { get; set; }

		protected void SpecialActionTimeout()
		{
			Thread.Sleep(SpecialActionTimeoutMilliseconds);
			if (RightMouseButtonDown)
			{
				SetAlternateSmileys();
				OnSpecialActionRequested(null);
				SpecialActionInvoked = true;
			}
		}

		protected MinesweeperGameState ParentFieldState
		{
			get
			{
				return ParentField.GameState;
			}
		}

		protected void OnParentFieldStateChanged(object sender, EventArgs e)
		{
			if (ParentFieldState == MinesweeperGameState.GameWon)
			{
				Image = SmileyOnWin;
			}
			else if (ParentFieldState == MinesweeperGameState.GameLost)
			{
				Image = SmileyOnLose;
			}
			else if (ParentFieldActive)
			{
				Image = SmileyStandard;
				ParentField.RegisterMouseDownEventHandler(OnForeignObjectMouseDown);
				ParentField.RegisterMouseUpEventHandler(OnForeignObjectMouseUp);
			}
		}

		public bool ParentFieldActive
		{
			get
			{
				return ParentFieldState == MinesweeperGameState.Unknown || ParentFieldState == MinesweeperGameState.GameInProgress;
			}
		}

		public IMineField ParentField
		{
			get
			{
				return parentField;
			}

			set
			{
				if (parentField != null)
				{
					try
					{
						parentField.GameEnded -= OnParentFieldStateChanged;
						parentField.NewGameStarted -= OnParentFieldStateChanged;
					}
					catch
					{

					}
				}

				parentField = value;
				parentField.GameEnded += new EventHandler(OnParentFieldStateChanged);
				parentField.NewGameStarted += new EventHandler(OnParentFieldStateChanged);
				parentField.CellsDrawn += new EventHandler(OnParentFieldStateChanged);
				SpecialActionInvoked = false;
				SetInitialSmileys();
			}
		}

		public void SetInitialSmileys()
		{
			SmileyStandard = ButtonImagesProvider.SmileyHappy;
			SmileyOnPress = ButtonImagesProvider.SmileyFrown;
			SmileyOnWin = ButtonImagesProvider.SmileyCool;
			SmileyOnLose = ButtonImagesProvider.SmileyAngel;
			Image = SmileyStandard;
		}

		public void SetAlternateSmileys()
		{
			SmileyStandard = ButtonImagesProvider.SmileyDevilNormal;
			SmileyOnPress = ButtonImagesProvider.SmileyDevilFrown;
			SmileyOnWin = ButtonImagesProvider.SmileyDevilLaugh;
			SmileyOnLose = ButtonImagesProvider.SmileyDevilLaugh;
			Image = SmileyStandard;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				RightMouseButtonDown = true;
				IAsyncResult timeout = (new Action(SpecialActionTimeout)).BeginInvoke(null, null);
			}
			else if (e.Button == MouseButtons.Left)
			{
				base.OnMouseDown(e);
				BackgroundImage = BackgroundPressed;
				if (ParentFieldActive)
				{
					Image = SmileyOnPress;
				}
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				RightMouseButtonDown = false;
			}
			else if (e.Button == MouseButtons.Left)
			{
				base.OnMouseUp(e);
				BackgroundImage = BackgroundNormal;
				if (ParentFieldActive)
				{
					Image = SmileyStandard;
				}
			}
		}

		protected void OnSpecialActionRequested(EventArgs e = null)
		{
			StatisticsTracker.BannedMineFields.Add(ParentField);
			if (SpecialActionRequested != null)
			{
				SpecialActionRequested(this, e);
			}
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			if (!SpecialActionInvoked && e.Button == MouseButtons.Left)
			{
				base.OnMouseClick(e);
			}
			else if (SpecialActionInvoked)
			{
				SpecialActionInvoked = false;
			}
		}

		public int SpecialActionTimeoutMilliseconds { get; set; }

		public event EventHandler SpecialActionRequested;

		public void OnForeignObjectMouseDown(object sender, MouseEventArgs e)
		{
			if (ParentFieldActive && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Middle))
			{
				Image = SmileyOnPress;
			}
		}

		public void OnForeignObjectMouseUp(object sender, MouseEventArgs e)
		{
			if (ParentFieldActive && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Middle))
			{
				Image = SmileyStandard;
			}
		}

		public SmileyFaceButton()
		{
			SetInitialSmileys();
			this.Padding = new System.Windows.Forms.Padding(1, 1, 0, 0);
			BackgroundImage = BackgroundNormal;
		}

		public SmileyFaceButton(IMineField parentField) :
			this()
		{
			ParentField = parentField;
		}
	}
}
