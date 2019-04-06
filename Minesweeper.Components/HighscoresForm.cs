using System.Windows.Forms;
using Minesweeper.Components;
using Minesweeper.Extensions;
using System.Collections.Generic;
using System.Drawing;

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

		private void SetHighscoreValues()
		{
			labelBeginnerScore.Text = StatisticsTracker.HighscoreBeginner.Key.ToString();
			textBoxBeginnerHiScore.Text = StatisticsTracker.HighscoreBeginner.Value.ToString();
			labelIntermediateScore.Text = StatisticsTracker.HighscoreIntermediate.Key.ToString();
			textBoxIntermHiScore.Text = StatisticsTracker.HighscoreIntermediate.Value.ToString();
			labelAdvancedScore.Text = StatisticsTracker.HighscoreAdvanced.Key.ToString();
			textBoxAdvancedHiScore.Text = StatisticsTracker.HighscoreAdvanced.Value.ToString();
		}

		public HighscoresForm(FieldConfiguration activeConfig, int currentScore) :
			this()
		{
			ActiveConfig = activeConfig;
			CurrentScore = currentScore;
		}

		public int Highscore { get; protected set; }

		public string PlayerName { get; protected set; }

		protected FieldConfiguration ActiveConfig { get; set; }

		protected int CurrentScore { get; set; }

		private void EnableInputOnNewHighscore()
		{
			if (CurrentScore < labelBeginnerScore.Text.ToInt32(999) && ActiveConfig.ConfigurationName == FieldConfiguration.BeginnerConfigString)
			{
				textBoxBeginnerHiScore.Enabled = true;
				labelBeginnerScore.Text = CurrentScore.ToString();
				textBoxBeginnerHiScore.TextChanged += new System.EventHandler(OnTextChanged);
				textBoxBeginnerHiScore.SelectionStart = 0;
				textBoxBeginnerHiScore.SelectionLength = textBoxBeginnerHiScore.Text.Length;
				textBoxBeginnerHiScore.Focus();
			}
			else if (CurrentScore < labelIntermediateScore.Text.ToInt32(999) && ActiveConfig.ConfigurationName == FieldConfiguration.IntermediateConfigString)
			{
				textBoxIntermHiScore.Enabled = true;
				labelIntermediateScore.Text = CurrentScore.ToString();
				textBoxIntermHiScore.TextChanged += new System.EventHandler(OnTextChanged);
				textBoxIntermHiScore.SelectionStart = 0;
				textBoxIntermHiScore.SelectionLength = textBoxBeginnerHiScore.Text.Length;
				textBoxIntermHiScore.Focus();
			}
			else if (CurrentScore < labelAdvancedScore.Text.ToInt32(999) && ActiveConfig.ConfigurationName == FieldConfiguration.AdvancedConfigString)
			{
				textBoxAdvancedHiScore.Enabled = true;
				labelAdvancedScore.Text = CurrentScore.ToString();
				textBoxAdvancedHiScore.TextChanged += new System.EventHandler(OnTextChanged);
				textBoxAdvancedHiScore.SelectionStart = 0;
				textBoxAdvancedHiScore.SelectionLength = textBoxBeginnerHiScore.Text.Length;
				textBoxAdvancedHiScore.Focus();
			}
			labelScoreInputTip.Visible = true;
		}

		void OnTextChanged(object sender, System.EventArgs e)
		{
			TextBox senderTextBox = sender as TextBox;
			if (senderTextBox != null)
			{
				PlayerName = senderTextBox.Text;
			}
		}

		private void OnAcceptButtonClick(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
