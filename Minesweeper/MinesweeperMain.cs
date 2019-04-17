using System;
using System.Windows.Forms;
using System.Drawing;
using Minesweeper.Components;

namespace Minesweeper
{
	public partial class MinesweeperMain : Form
	{
		public static Point DefaultFieldLocation
		{
			get
			{
				return new Point(9, 9);
			}
		}

		public MinesweeperMain()
		{
			SuspendLayout();
			InitializeComponent();
			NormalizeLayoutAndValues();
			ResumeLayout();
		}

		public IMineField InternalMineField
		{
			get
			{
				return field;
			}
		}

		private void OnMainWindowLoad(object sender, EventArgs e)
		{
			field.DrawCells();
		}

		private void OnTimerTick(object sender, EventArgs e)
		{
			Timer timerSender = sender as Timer;
			if (timerSender != null)
			{
				mineLabelTime.Value += timerSender.Interval / 1000;
			}
		}

		private void OnSmileyFaceClick(object sender, EventArgs e)
		{
			
		}

		private void CheatDebugMineCellPreview(object sender, EventArgs e)
		{
			if (field.GameStarted)
			{
				this.toolStripLabelDebugHelper.Text = sender.ToString();
			}
		}

		private void OnLeaderboardMenuItemClick(object sender, EventArgs e)
		{
            StatisticsTracker.Instance.ShowLeaderboard(this);
		}

		private void OnStatisticsMenuItemClick(object sender, EventArgs e)
		{
            StatisticsTracker.Instance.ShowStatistics(this);
		}

		private void OnCheatRequested(object sender, EventArgs e)
		{
			field.RegisterMouseEnterEventHandler(new EventHandler(CheatDebugMineCellPreview));
		}
	}
}
