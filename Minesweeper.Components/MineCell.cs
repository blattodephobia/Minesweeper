using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using Minesweeper.Extensions;
using Minesweeper.Resources;

namespace Minesweeper.Components
{
	public delegate int SquareOpenedEventHandler(object sender, EventArgs e);

	public enum MineCellCommand { Open, Expand, Defuse };

	public enum MineCellState { Closed, Opened, Exploded, Defused };

	public class MineCell : PictureBox, IMineSquare
	{
		private int neighbouringBombsCount;

		private MineCellState state;

		private string toString;

		private void Open()
		{
			if (!Defused && !Opened)
			{
				if (ContainsBomb)
				{
					Image = stateImagesTable[MineCellState.Exploded];
					state = MineCellState.Exploded;
				}
				else
				{
					Image = numberedSquaresTable[NeighbouringBombsCount];
				}
			}
		}

		private void ResetSquare()
		{
			Image = stateImagesTable[MineCellState.Closed];
		}

		protected static Dictionary<MineCellState, Bitmap> stateImagesTable = new Dictionary<MineCellState, Bitmap>()
		{
			{ MineCellState.Opened, CellImagesProvider.Blank },
			{ MineCellState.Closed, CellImagesProvider.Default },
			{ MineCellState.Defused, CellImagesProvider.Defused },
			{ MineCellState.Exploded, CellImagesProvider.Exploded }
		};

		protected static Dictionary<int, Bitmap> numberedSquaresTable = new Dictionary<int, Bitmap>()
		{
			{ 0, CellImagesProvider.Blank },
			{ 1, CellImagesProvider.NumberedSquare1 },
			{ 2, CellImagesProvider.NumberedSquare2 },
			{ 3, CellImagesProvider.NumberedSquare3 },
			{ 4, CellImagesProvider.NumberedSquare4 },
			{ 5, CellImagesProvider.NumberedSquare5 },
			{ 6, CellImagesProvider.NumberedSquare6 },
			{ 7, CellImagesProvider.NumberedSquare7 },
			{ 8, CellImagesProvider.NumberedSquare8 }
		};

		protected MineCellCommand GetCommand(MouseEventArgs e)
		{
			if (e == null)
			{
				return MineCellCommand.Open;
			}

			bool commandExpandRequested = e.Button == MouseButtons.Middle;
			bool commandOpenRequested = e.Button == MouseButtons.Left;
			bool commandDefuseRequested = e.Button == MouseButtons.Right;
			if (commandExpandRequested)
			{
				return MineCellCommand.Expand;
			}
			else if (commandOpenRequested)
			{
				return MineCellCommand.Open;
			}
			else if (commandDefuseRequested)
			{
				return MineCellCommand.Defuse;
			}
			else
			{
				throw new System.InvalidOperationException();
			}
		}

		protected static void OnButtonDown(MineCell obj)
		{
			if (!obj.Opened && !obj.Defused)
			{
				obj.Image = CellImagesProvider.Pressed;
			}
		}

		protected static void OnButtonUp(MineCell obj)
		{
			if (!obj.Opened && !obj.Defused)
			{
				obj.Image = CellImagesProvider.Default;
			}
		}

		protected void OnStateChanged()
		{
			if (StateChanged != null)
			{
				StateChanged(this);
			}
		}

		protected void OnExploded()
		{
			this.Enabled = false;
			if (Exploded != null)
			{
				Exploded(this);
			}
		}

		protected static readonly Size standardSize = new Size(16, 16);

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			Size = standardSize;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left && !Opened && !Defused)
			{
				OnButtonDown(this);
			}
			else if (e.Button == MouseButtons.Middle && Opened && !Defused)
			{
				IEnumerable<MineCell> neighbours = ParentBoard.GetNeighbours(FieldLocation).ConvertTo<IMineSquare, MineCell>();
				neighbours.ForEach(OnButtonDown);
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			RestoreImages(e);
			base.OnMouseUp(e);
			MouseEventArgs eventArgs = e as MouseEventArgs;
			MineCellCommand requestedCommand = GetCommand(eventArgs);
			ExecuteCommand(requestedCommand);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			MouseEntered = true;
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			MouseEntered = false;
		}

		protected bool MouseEntered { get; set; }

		private void RestoreImages(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && !Defused && !Opened)
			{
				Image = CellImagesProvider.Default;
			}
			else if (e.Button == MouseButtons.Middle && !Defused && Opened)
			{
				IEnumerable<MineCell> neighbours = ParentBoard.GetNeighbours(FieldLocation).ConvertTo<IMineSquare, MineCell>();
				neighbours.ForEach(OnButtonUp);
			}
		}

		private void ExecuteCommand(MineCellCommand requestedCommand)
		{
			if (!Opened)
			{
				if (requestedCommand == MineCellCommand.Open && !Defused)
				{
					if (ContainsBomb)
					{
						State = MineCellState.Exploded;
						OnStateChanged();
					}
					else
					{
						Image = numberedSquaresTable[NeighbouringBombsCount];
						if (NeighbouringBombsCount == 0)
						{
							Parent.SuspendLayout();
							ParentBoard.TryExpandZeroSquares(FieldLocation);
							Parent.ResumeLayout();
						}
					}
					State = MineCellState.Opened;
				}
				else if (requestedCommand == MineCellCommand.Defuse)
				{
					State = Defused ? MineCellState.Closed : MineCellState.Defused;
				}
			}
			else if (requestedCommand == MineCellCommand.Expand)
			{
				ParentBoard.TryExpandNonZeroSquare(this.FieldLocation);
			}
		}

		protected void OnClickDeprecated(EventArgs e)
		{
			MouseEventArgs eventArgs = e as MouseEventArgs;
			if (!Opened)
			{
				if (!Defused && eventArgs.Button == MouseButtons.Left)
				{
					if (ContainsBomb)
					{
						OnStateChanged();
					}
					else
					{
						Image = numberedSquaresTable[NeighbouringBombsCount];
						if (NeighbouringBombsCount == 0)
						{
							Parent.SuspendLayout();
							ParentBoard.TryExpandZeroSquares(FieldLocation);
							Parent.ResumeLayout();
						}
					}
					State = MineCellState.Opened;
				}
				else if (eventArgs.Button == MouseButtons.Right)
				{
					Image = Image == CellImagesProvider.Defused ? CellImagesProvider.Default : CellImagesProvider.Defused;
					State = Defused ? MineCellState.Closed : MineCellState.Defused;
				}
			}
			else if (eventArgs.Button == MouseButtons.Middle)
			{
				ParentBoard.TryExpandNonZeroSquare(this.FieldLocation);
			}
		}

		public static Size StandardSize
		{
			get
			{
				return standardSize;
			}
		}

		public bool Opened
		{
			get
			{
				return State == MineCellState.Opened || State == MineCellState.Exploded;
			}
		}

		public MineCellState State
		{
			get
			{
				return state;
			}

			set
			{
				if (state != value)
				{
					if (value != MineCellState.Opened && value != MineCellState.Closed)
					{
						Image = stateImagesTable[value];
					}
					else
					{
						if (value == MineCellState.Opened)
						{
							Open();
						}
						else
						{
							ResetSquare();
						}
					}
					NormalizeState(value);
					toString = null;
					OnStateChanged();
				}
			}

		}

		private void NormalizeState(MineCellState value)
		{
			state = value == MineCellState.Opened && ContainsBomb ? MineCellState.Exploded : value;
		}

		public bool Defused
		{
			get
			{
				return State == MineCellState.Defused;
			}
		}

		public IMineField ParentBoard { get; set; }

		public bool ContainsBomb { get; set; }

		public Point FieldLocation { get; set; }

		public Point ControlLocation
		{
			get
			{
				return Location;
			}

			set
			{
				Location = value;
			}
		}

		public event Action<MineCell> Exploded;

		public event Action<MineCell> StateChanged;

		public int NeighbouringBombsCount
		{
			get
			{
				if (neighbouringBombsCount == -1)
				{
					neighbouringBombsCount = NeighbouringBombsEnumerator(this);
				}

				return neighbouringBombsCount;
			}
		}

		Point IMineSquare.ControlLocation
		{
			get
			{
				return base.Location;
			}

			set
			{
				base.Location = value;
			}
		}

		public EnumerateNeighbouringBombsDelegate NeighbouringBombsEnumerator { get; set; }

		public void RevealBomb()
		{
			if (ContainsBomb && !Opened && !Defused)
			{
				Image = CellImagesProvider.Bomb;
			}
			else if (!ContainsBomb && Defused)
			{
				Image = CellImagesProvider.False;
			}
		}

		public MineCell()
		{
			base.Size = new System.Drawing.Size(16, 16);
			Image = CellImagesProvider.Default;
			neighbouringBombsCount = -1;
		}

		public override string ToString()
		{
			if (toString == null)
			{
				toString = string.Format("{0};{1};{2};{3};", Location.ToString(), State.ToString(), NeighbouringBombsCount, ContainsBomb ? "Bomb" : "Empty");
			}

			return toString;
		}

		public override int GetHashCode()
		{
			return FieldLocation.GetHashCode();
		}
	}
}