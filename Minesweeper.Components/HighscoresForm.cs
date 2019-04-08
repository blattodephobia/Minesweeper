using System.Windows.Forms;
using Minesweeper.Components;
using Minesweeper.Extensions;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace Minesweeper
{
	public partial class HighscoresForm : Form
	{
		public HighscoresForm()
		{
			InitializeComponent();
			this.acceptButton.Location = new Point((this.Size.Width - this.acceptButton.Width) / 2, this.acceptButton.Location.Y);
			SetHighscoreValues();
		}

		public HighscoresForm(FieldConfiguration activeConfig, int currentScore) :
			this()
		{
			ActiveConfig = activeConfig;
			CurrentScore = currentScore;

            TextBox targetTb = null;
            if (ActiveConfig?.ConfigurationName == FieldConfiguration.BeginnerConfigString)
            {
                targetTb = textBoxBeginnerHiScore;
            }
            else if (ActiveConfig?.ConfigurationName == FieldConfiguration.IntermediateConfigString)
            {
                targetTb = textBoxIntermHiScore;
            }
            else if (ActiveConfig?.ConfigurationName == FieldConfiguration.AdvancedConfigString)
            {
                targetTb = textBoxAdvancedHiScore;
            }

            ViewModel = new HighscoreViewModelImpl(this, targetTb) { CanEditPlayerName = true };
		}

        public HighscoreViewModel ViewModel { get; set; }

		public int Highscore { get; protected set; }

		protected FieldConfiguration ActiveConfig { get; set; }

		protected int CurrentScore { get; set; }

		private void SetHighscoreValues()
		{
			labelBeginnerScore.Text = StatisticsTracker.HighscoreBeginner.Key.ToString();
			textBoxBeginnerHiScore.Text = StatisticsTracker.HighscoreBeginner.Value.ToString();
			labelIntermediateScore.Text = StatisticsTracker.HighscoreIntermediate.Key.ToString();
			textBoxIntermHiScore.Text = StatisticsTracker.HighscoreIntermediate.Value.ToString();
			labelAdvancedScore.Text = StatisticsTracker.HighscoreAdvanced.Key.ToString();
			textBoxAdvancedHiScore.Text = StatisticsTracker.HighscoreAdvanced.Value.ToString();
		}

		private void EnableInputOnNewHighscore()
		{
			if (CurrentScore < labelBeginnerScore.Text.ToInt32(999) && ActiveConfig.ConfigurationName == FieldConfiguration.BeginnerConfigString)
			{
				textBoxBeginnerHiScore.Enabled = true;
				labelBeginnerScore.Text = CurrentScore.ToString();
				textBoxBeginnerHiScore.SelectionStart = 0;
				textBoxBeginnerHiScore.SelectionLength = textBoxBeginnerHiScore.Text.Length;
				textBoxBeginnerHiScore.Focus();
			}
			else if (CurrentScore < labelIntermediateScore.Text.ToInt32(999) && ActiveConfig.ConfigurationName == FieldConfiguration.IntermediateConfigString)
			{
				textBoxIntermHiScore.Enabled = true;
				labelIntermediateScore.Text = CurrentScore.ToString();
				textBoxIntermHiScore.SelectionStart = 0;
				textBoxIntermHiScore.SelectionLength = textBoxBeginnerHiScore.Text.Length;
				textBoxIntermHiScore.Focus();
			}
			else if (CurrentScore < labelAdvancedScore.Text.ToInt32(999) && ActiveConfig.ConfigurationName == FieldConfiguration.AdvancedConfigString)
			{
				textBoxAdvancedHiScore.Enabled = true;
				labelAdvancedScore.Text = CurrentScore.ToString();
				textBoxAdvancedHiScore.SelectionStart = 0;
				textBoxAdvancedHiScore.SelectionLength = textBoxBeginnerHiScore.Text.Length;
				textBoxAdvancedHiScore.Focus();
			}
			labelScoreInputTip.Visible = true;
		}

		private void OnAcceptButtonClick(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
