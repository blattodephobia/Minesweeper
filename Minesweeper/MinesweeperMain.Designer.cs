using System.Windows.Forms;
using System.Drawing;
using Minesweeper.Components;
using Minesweeper.Resources;
using System;

namespace Minesweeper
{
	partial class MinesweeperMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinesweeperMain));
			this.timerIntervalSeconds = new System.Windows.Forms.Timer(this.components);
			this.menuStripMain = new System.Windows.Forms.MenuStrip();
			this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.leaderboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripLabelDebugHelper = new System.Windows.Forms.ToolStripStatusLabel();
			this.panelHudPlaceHolder = new System.Windows.Forms.Panel();
			this.mineLabelBombsCount = new Minesweeper.Components.MineLabel();
			this.buttonSmileyFace = new Minesweeper.Components.SmileyFaceButton();
			this.field = new Minesweeper.Components.MineField();
			this.mineLabelTime = new Minesweeper.Components.MineLabel();
			this.menuStripMain.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.panelHudPlaceHolder.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.buttonSmileyFace)).BeginInit();
			this.SuspendLayout();
			// 
			// timerIntervalSeconds
			// 
			this.timerIntervalSeconds.Interval = 1000;
			this.timerIntervalSeconds.Tick += new System.EventHandler(this.OnTimerTick);
			// 
			// menuStripMain
			// 
			this.menuStripMain.GripMargin = new System.Windows.Forms.Padding(0);
			this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStripMain.Location = new System.Drawing.Point(0, 0);
			this.menuStripMain.Name = "menuStripMain";
			this.menuStripMain.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
			this.menuStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.menuStripMain.Size = new System.Drawing.Size(196, 24);
			this.menuStripMain.TabIndex = 2;
			this.menuStripMain.Text = "menuStrip1";
			// 
			// gameToolStripMenuItem
			// 
			this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.statisticsToolStripMenuItem,
            this.leaderboardToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
			this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
			this.gameToolStripMenuItem.Text = "&Game";
			// 
			// newGameToolStripMenuItem
			// 
			this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
			this.newGameToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
			this.newGameToolStripMenuItem.Text = "&New Game";
			this.newGameToolStripMenuItem.Click += new System.EventHandler(this.OnMenuNewGameRequested);
			// 
			// statisticsToolStripMenuItem
			// 
			this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
			this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
			this.statisticsToolStripMenuItem.Text = "Statistics";
			this.statisticsToolStripMenuItem.Click += new System.EventHandler(this.OnStatisticsMenuItemClick);
			// 
			// leaderboardToolStripMenuItem
			// 
			this.leaderboardToolStripMenuItem.Name = "leaderboardToolStripMenuItem";
			this.leaderboardToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
			this.leaderboardToolStripMenuItem.Text = "Leaderboard";
			this.leaderboardToolStripMenuItem.Click += new System.EventHandler(this.OnLeaderboardMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExit);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.aboutToolStripMenuItem.Text = "&About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnAboutInfoRequested);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelDebugHelper});
			this.statusStrip.Location = new System.Drawing.Point(0, 230);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(196, 22);
			this.statusStrip.SizingGrip = false;
			this.statusStrip.TabIndex = 5;
			// 
			// toolStripLabelDebugHelper
			// 
			this.toolStripLabelDebugHelper.Name = "toolStripLabelDebugHelper";
			this.toolStripLabelDebugHelper.Size = new System.Drawing.Size(0, 17);
			this.toolStripLabelDebugHelper.Text = "Ready";
			// 
			// panelHudPlaceHolder
			// 
			this.panelHudPlaceHolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelHudPlaceHolder.Controls.Add(this.mineLabelBombsCount);
			this.panelHudPlaceHolder.Controls.Add(this.buttonSmileyFace);
			this.panelHudPlaceHolder.Controls.Add(this.mineLabelTime);
			this.panelHudPlaceHolder.Location = new System.Drawing.Point(0, 27);
			this.panelHudPlaceHolder.Name = "panelHudPlaceHolder";
			this.panelHudPlaceHolder.Size = new System.Drawing.Size(196, 28);
			this.panelHudPlaceHolder.TabIndex = 7;
			// 
			// mineLabelBombsCount
			// 
			this.mineLabelBombsCount.BackColor = System.Drawing.Color.Black;
			this.mineLabelBombsCount.Font = new System.Drawing.Font("LCDDot TR", 24F);
			this.mineLabelBombsCount.ForeColor = System.Drawing.Color.Red;
			this.mineLabelBombsCount.Location = new System.Drawing.Point(0, 0);
			this.mineLabelBombsCount.Margin = new System.Windows.Forms.Padding(0);
			this.mineLabelBombsCount.Name = "mineLabelBombsCount";
			this.mineLabelBombsCount.Padding = new System.Windows.Forms.Padding(2, 4, 0, 0);
			this.mineLabelBombsCount.Size = new System.Drawing.Size(46, 26);
			this.mineLabelBombsCount.TabIndex = 3;
			this.mineLabelBombsCount.Text = "000";
			this.mineLabelBombsCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mineLabelBombsCount.Value = 0;
			// 
			// field
			// 
			this.field.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.field.Location = new System.Drawing.Point(22, 68);
			this.field.Name = "field";
			this.field.Padding = new System.Windows.Forms.Padding(5);
			this.field.Size = new System.Drawing.Size(152, 159);
			this.field.TabIndex = 0;
			this.field.NewGameStarted += new System.EventHandler(this.OnNewGameStarted);
			this.field.GameEnded += new System.EventHandler(this.OnGameEnded);
			this.field.RemainingBombsCountChanged += new System.EventHandler(this.OnBombsCountChanged);
			// 
			// buttonSmileyFace
			// 
			this.buttonSmileyFace.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSmileyFace.BackgroundImage")));
			this.buttonSmileyFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.buttonSmileyFace.Image = ((System.Drawing.Image)(resources.GetObject("buttonSmileyFace.Image")));
			this.buttonSmileyFace.Location = new System.Drawing.Point(87, 0);
			this.buttonSmileyFace.Name = "buttonSmileyFace";
			this.buttonSmileyFace.Padding = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.buttonSmileyFace.ParentField = this.field;
			this.buttonSmileyFace.Size = new System.Drawing.Size(24, 24);
			this.buttonSmileyFace.SpecialActionTimeoutMilliseconds = 3000;
			this.buttonSmileyFace.SpecialActionRequested += new EventHandler(OnCheatRequested);
			this.buttonSmileyFace.TabIndex = 6;
			this.buttonSmileyFace.TabStop = false;
			this.buttonSmileyFace.Click += new System.EventHandler(this.OnButtonNewGameRequested);
			// 
			// mineLabelTime
			// 
			this.mineLabelTime.BackColor = System.Drawing.Color.Black;
			this.mineLabelTime.Font = new System.Drawing.Font("LCDDot TR", 24F);
			this.mineLabelTime.ForeColor = System.Drawing.Color.Red;
			this.mineLabelTime.Location = new System.Drawing.Point(145, 0);
			this.mineLabelTime.Margin = new System.Windows.Forms.Padding(0);
			this.mineLabelTime.Name = "mineLabelTime";
			this.mineLabelTime.Padding = new System.Windows.Forms.Padding(2, 4, 0, 0);
			this.mineLabelTime.Size = new System.Drawing.Size(49, 26);
			this.mineLabelTime.TabIndex = 4;
			this.mineLabelTime.Text = "000";
			this.mineLabelTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.mineLabelTime.Value = 0;
			// 
			// MinesweeperMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(196, 252);
			this.Controls.Add(this.field);
			this.Controls.Add(this.panelHudPlaceHolder);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStripMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStripMain;
			this.MaximizeBox = false;
			this.Name = "MinesweeperMain";
			this.Text = "Minesweeper";
			this.Load += new System.EventHandler(this.OnMainWindowLoad);
			this.menuStripMain.ResumeLayout(false);
			this.menuStripMain.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.panelHudPlaceHolder.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.buttonSmileyFace)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		void OnGameEnded(object sender, EventArgs e)
		{
			timerIntervalSeconds.Stop();
			if (field.GameWon)
			{
                StatisticsTracker.Instance.GamesWon++;
                StatisticsTracker.Instance.TrySetPlayerNameOnNewHighscore(field.CurrentConfiguration, mineLabelTime.Value, this);
			}
			toolStripLabelDebugHelper.Text = field.GameWon ? "You win!" : "You lose!";
		}

		void OnNewGameStarted(object sender, EventArgs e)
		{
			timerIntervalSeconds.Stop();
			mineLabelTime.Text = "0";
			timerIntervalSeconds.Start();
            StatisticsTracker.Instance.GamesPlayed++;
			toolStripLabelDebugHelper.Text = "Ready";
		}

		void OnBombsCountChanged(object sender, EventArgs e)
		{
			mineLabelBombsCount.Value = field.ViewModel.RemainingBombs;
		}

		void OnAboutInfoRequested(object sender, EventArgs e)
		{
			using (Form aboutInfoForm = new AboutDialog())
			{
				aboutInfoForm.ShowDialog(this);
			}
		}

		protected virtual void OnExit(object sender, System.EventArgs e)
		{
			this.Close();
			Application.Exit();
		}

		protected virtual void OnMenuNewGameRequested(object sender, System.EventArgs e)
		{
			timerIntervalSeconds.Stop();
			if (!CanProceedWithNewGame())
			{
				timerIntervalSeconds.Start();
			}
			else
			{
				GameParamsSelectionForm newGameSelection = new GameParamsSelectionForm();
				if (newGameSelection.ShowDialog(this) == DialogResult.OK)
				{
					toolStripLabelDebugHelper.Text = "Ready";
					StartNewGame(newGameSelection.SelectedConfig);
				}
				else if (this.field.GameStarted)
				{
					timerIntervalSeconds.Start();
				}
			}
		}

		protected virtual void OnButtonNewGameRequested(object sender, EventArgs e)
		{
			MouseEventArgs buttonEventArgs = e as MouseEventArgs;
			if (buttonEventArgs != null && buttonEventArgs.Button == MouseButtons.Left && CanProceedWithNewGame())
			{
				toolStripLabelDebugHelper.Text = "Ready";
				StartNewGame(field.CurrentConfiguration);
			}
		}

		protected bool CanProceedWithNewGame()
		{
			return !this.field.GameStarted || UserConfirmedAction(StringsProvider.ConfirmNewGame);
		}

		private void StartNewGame(FieldConfiguration config)
		{
			this.SuspendLayout();
			this.Controls.Remove(field);
			field = new MineField(config);
			this.field.Location = new System.Drawing.Point(0, menuStripMain.Height);
			this.field.Name = "field";
			this.field.Size = new System.Drawing.Size(152, 159);
			this.field.TabIndex = 0;
			this.field.NewGameStarted += new System.EventHandler(this.OnNewGameStarted);
			this.field.RemainingBombsCountChanged += new System.EventHandler(this.OnBombsCountChanged);
			this.field.GameEnded += new EventHandler(OnGameEnded);
			this.field.DrawCells();
			this.Controls.Add(field);
			this.mineLabelBombsCount.Value = config.MinesCount;
			this.mineLabelTime.Value = 0;
			this.buttonSmileyFace.ParentField = field;
			NormalizeLayoutAndValues();
			this.ResumeLayout();
		}

		private void NormalizeLayoutAndValues()
		{
			this.field.Location = new Point(0, menuStripMain.Height + panelHudPlaceHolder.Height + 2);
			this.Size = new Size(field.Columns * 16 + field.Location.X + 9, field.Rows * 16 + field.Location.Y + statusStrip.Height+ 32);
			this.panelHudPlaceHolder.Size = new Size(this.Width - 7, this.panelHudPlaceHolder.Height);
			this.panelHudPlaceHolder.Location = new Point(1, menuStripMain.Height);
			this.mineLabelBombsCount.Location = new Point(0, 0);
			this.mineLabelBombsCount.Value = field.CurrentConfiguration.MinesCount;
			this.mineLabelTime.Location = new Point(this.panelHudPlaceHolder.Width - this.mineLabelTime.Width - 4, 0);
			this.buttonSmileyFace.Location = new Point((this.panelHudPlaceHolder.Width - this.buttonSmileyFace.Width) / 2, 0);
		}

		protected bool UserConfirmedAction(string message)
		{
			return MessageBox.Show(message, "Confirm action", MessageBoxButtons.OKCancel) == DialogResult.OK;
		}

		#endregion

		private MineField field;
		private System.Windows.Forms.Timer timerIntervalSeconds;
		private MenuStrip menuStripMain;
		private ToolStripMenuItem gameToolStripMenuItem;
		private ToolStripMenuItem newGameToolStripMenuItem;
		private ToolStripMenuItem exitToolStripMenuItem;
		private ToolStripMenuItem helpToolStripMenuItem;
		private ToolStripMenuItem aboutToolStripMenuItem;
		private Minesweeper.Components.MineLabel mineLabelBombsCount;
		private Minesweeper.Components.MineLabel mineLabelTime;
		private StatusStrip statusStrip;
		private SmileyFaceButton buttonSmileyFace;
		private Panel panelHudPlaceHolder;
		private ToolStripMenuItem leaderboardToolStripMenuItem;
		private ToolStripMenuItem statisticsToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripStatusLabel toolStripLabelDebugHelper;
	}
}

