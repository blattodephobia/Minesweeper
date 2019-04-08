using System;
using System.Drawing;
namespace Minesweeper
{
	partial class HighscoresForm
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
                (ViewModel as IDisposable)?.Dispose();
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
			this.acceptButton = new System.Windows.Forms.Button();
			this.labelBeginner = new System.Windows.Forms.Label();
			this.labelIntermediate = new System.Windows.Forms.Label();
			this.labelAdvanced = new System.Windows.Forms.Label();
			this.textBoxBeginnerHiScore = new System.Windows.Forms.TextBox();
			this.textBoxIntermHiScore = new System.Windows.Forms.TextBox();
			this.textBoxAdvancedHiScore = new System.Windows.Forms.TextBox();
			this.labelBeginnerScore = new System.Windows.Forms.Label();
			this.labelIntermediateScore = new System.Windows.Forms.Label();
			this.labelAdvancedScore = new System.Windows.Forms.Label();
			this.groupBoxConfigNames = new System.Windows.Forms.GroupBox();
			this.groupBoxScores = new System.Windows.Forms.GroupBox();
			this.groupBoxPlayerNames = new System.Windows.Forms.GroupBox();
			this.labelScoreInputTip = new System.Windows.Forms.Label();
			this.groupBoxConfigNames.SuspendLayout();
			this.groupBoxScores.SuspendLayout();
			this.groupBoxPlayerNames.SuspendLayout();
			this.SuspendLayout();
			// 
			// acceptButton
			// 
			this.acceptButton.Location = new System.Drawing.Point(96, 147);
			this.acceptButton.Name = "acceptButton";
			this.acceptButton.Size = new System.Drawing.Size(90, 23);
			this.acceptButton.TabIndex = 0;
			this.acceptButton.Text = "OK";
			this.acceptButton.UseVisualStyleBackColor = true;
			this.acceptButton.Click += new System.EventHandler(this.OnAcceptButtonClick);
			// 
			// labelBeginner
			// 
			this.labelBeginner.AutoSize = true;
			this.labelBeginner.Location = new System.Drawing.Point(6, 20);
			this.labelBeginner.Name = "labelBeginner";
			this.labelBeginner.Size = new System.Drawing.Size(52, 13);
			this.labelBeginner.TabIndex = 1;
			this.labelBeginner.Text = "Beginner:";
			// 
			// labelIntermediate
			// 
			this.labelIntermediate.AutoSize = true;
			this.labelIntermediate.Location = new System.Drawing.Point(6, 46);
			this.labelIntermediate.Name = "labelIntermediate";
			this.labelIntermediate.Size = new System.Drawing.Size(68, 13);
			this.labelIntermediate.TabIndex = 2;
			this.labelIntermediate.Text = "Intermediate:";
			// 
			// labelAdvanced
			// 
			this.labelAdvanced.AutoSize = true;
			this.labelAdvanced.Location = new System.Drawing.Point(6, 72);
			this.labelAdvanced.Name = "labelAdvanced";
			this.labelAdvanced.Size = new System.Drawing.Size(59, 13);
			this.labelAdvanced.TabIndex = 3;
			this.labelAdvanced.Text = "Advanced:";
			// 
			// textBoxBeginnerHiScore
			// 
			this.textBoxBeginnerHiScore.Enabled = false;
			this.textBoxBeginnerHiScore.Location = new System.Drawing.Point(6, 17);
			this.textBoxBeginnerHiScore.Name = "textBoxBeginnerHiScore";
			this.textBoxBeginnerHiScore.Size = new System.Drawing.Size(100, 20);
			this.textBoxBeginnerHiScore.TabIndex = 4;
			// 
			// textBoxIntermHiScore
			// 
			this.textBoxIntermHiScore.Enabled = false;
			this.textBoxIntermHiScore.Location = new System.Drawing.Point(6, 43);
			this.textBoxIntermHiScore.Name = "textBoxIntermHiScore";
			this.textBoxIntermHiScore.Size = new System.Drawing.Size(100, 20);
			this.textBoxIntermHiScore.TabIndex = 5;
			// 
			// textBoxAdvancedHiScore
			// 
			this.textBoxAdvancedHiScore.Enabled = false;
			this.textBoxAdvancedHiScore.Location = new System.Drawing.Point(6, 69);
			this.textBoxAdvancedHiScore.Name = "textBoxAdvancedHiScore";
			this.textBoxAdvancedHiScore.Size = new System.Drawing.Size(100, 20);
			this.textBoxAdvancedHiScore.TabIndex = 6;
			// 
			// labelBeginnerScore
			// 
			this.labelBeginnerScore.Location = new System.Drawing.Point(6, 20);
			this.labelBeginnerScore.Name = "labelBeginnerScore";
			this.labelBeginnerScore.Size = new System.Drawing.Size(39, 13);
			this.labelBeginnerScore.TabIndex = 7;
			this.labelBeginnerScore.Text = "999";
			this.labelBeginnerScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelIntermediateScore
			// 
			this.labelIntermediateScore.Location = new System.Drawing.Point(6, 46);
			this.labelIntermediateScore.Name = "labelIntermediateScore";
			this.labelIntermediateScore.Size = new System.Drawing.Size(39, 13);
			this.labelIntermediateScore.TabIndex = 9;
			this.labelIntermediateScore.Text = "999";
			this.labelIntermediateScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelAdvancedScore
			// 
			this.labelAdvancedScore.Location = new System.Drawing.Point(6, 72);
			this.labelAdvancedScore.Name = "labelAdvancedScore";
			this.labelAdvancedScore.Size = new System.Drawing.Size(39, 13);
			this.labelAdvancedScore.TabIndex = 10;
			this.labelAdvancedScore.Text = "999";
			this.labelAdvancedScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBoxConfigNames
			// 
			this.groupBoxConfigNames.Controls.Add(this.labelBeginner);
			this.groupBoxConfigNames.Controls.Add(this.labelIntermediate);
			this.groupBoxConfigNames.Controls.Add(this.labelAdvanced);
			this.groupBoxConfigNames.Location = new System.Drawing.Point(12, 6);
			this.groupBoxConfigNames.Name = "groupBoxConfigNames";
			this.groupBoxConfigNames.Size = new System.Drawing.Size(78, 100);
			this.groupBoxConfigNames.TabIndex = 12;
			this.groupBoxConfigNames.TabStop = false;
			this.groupBoxConfigNames.Text = "Board type";
			// 
			// groupBoxScores
			// 
			this.groupBoxScores.Controls.Add(this.labelBeginnerScore);
			this.groupBoxScores.Controls.Add(this.labelIntermediateScore);
			this.groupBoxScores.Controls.Add(this.labelAdvancedScore);
			this.groupBoxScores.Location = new System.Drawing.Point(96, 6);
			this.groupBoxScores.Name = "groupBoxScores";
			this.groupBoxScores.Size = new System.Drawing.Size(51, 100);
			this.groupBoxScores.TabIndex = 13;
			this.groupBoxScores.TabStop = false;
			this.groupBoxScores.Text = "Score";
			// 
			// groupBoxPlayerNames
			// 
			this.groupBoxPlayerNames.Controls.Add(this.textBoxBeginnerHiScore);
			this.groupBoxPlayerNames.Controls.Add(this.textBoxIntermHiScore);
			this.groupBoxPlayerNames.Controls.Add(this.textBoxAdvancedHiScore);
			this.groupBoxPlayerNames.Location = new System.Drawing.Point(153, 6);
			this.groupBoxPlayerNames.Name = "groupBoxPlayerNames";
			this.groupBoxPlayerNames.Size = new System.Drawing.Size(112, 100);
			this.groupBoxPlayerNames.TabIndex = 14;
			this.groupBoxPlayerNames.TabStop = false;
			this.groupBoxPlayerNames.Text = "Player";
			// 
			// labelScoreInputTip
			// 
			this.labelScoreInputTip.Location = new System.Drawing.Point(12, 113);
			this.labelScoreInputTip.Name = "labelScoreInputTip";
			this.labelScoreInputTip.Size = new System.Drawing.Size(253, 31);
			this.labelScoreInputTip.TabIndex = 15;
			this.labelScoreInputTip.Text = "You have achieved a new highscore!\r\nEnter your name in the highlighted text box.";
			this.labelScoreInputTip.Visible = false;
			// 
			// HighscoresForm
			// 
			this.AcceptButton = this.acceptButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(277, 180);
			this.Controls.Add(this.labelScoreInputTip);
			this.Controls.Add(this.groupBoxPlayerNames);
			this.Controls.Add(this.groupBoxScores);
			this.Controls.Add(this.groupBoxConfigNames);
			this.Controls.Add(this.acceptButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HighscoresForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Highscores";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
			this.Shown += new System.EventHandler(this.OnFormShown);
			this.groupBoxConfigNames.ResumeLayout(false);
			this.groupBoxConfigNames.PerformLayout();
			this.groupBoxScores.ResumeLayout(false);
			this.groupBoxPlayerNames.ResumeLayout(false);
			this.groupBoxPlayerNames.PerformLayout();
			this.ResumeLayout(false);

		}

		void OnFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			if (CurrentScore != 0 && ActiveConfig != null)
			{
				Highscore = CurrentScore;
			}
		}

		void OnFormShown(object sender, System.EventArgs e)
		{
			if (ActiveConfig != null && CurrentScore != 0)
			{
				EnableInputOnNewHighscore();
			}
		}

		#endregion

		private System.Windows.Forms.Button acceptButton;
		private System.Windows.Forms.Label labelBeginner;
		private System.Windows.Forms.Label labelIntermediate;
		private System.Windows.Forms.Label labelAdvanced;
		private System.Windows.Forms.TextBox textBoxBeginnerHiScore;
		private System.Windows.Forms.TextBox textBoxIntermHiScore;
		private System.Windows.Forms.TextBox textBoxAdvancedHiScore;
		private System.Windows.Forms.Label labelBeginnerScore;
		private System.Windows.Forms.Label labelIntermediateScore;
		private System.Windows.Forms.Label labelAdvancedScore;
		private System.Windows.Forms.GroupBox groupBoxConfigNames;
		private System.Windows.Forms.GroupBox groupBoxScores;
		private System.Windows.Forms.GroupBox groupBoxPlayerNames;
		private System.Windows.Forms.Label labelScoreInputTip;
	}
}