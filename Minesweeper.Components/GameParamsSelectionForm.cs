using System;
using System.Windows.Forms;

namespace Minesweeper.Components
{
	public partial class GameParamsSelectionForm : Form
	{
		protected void DisableCustomSelectors()
		{
			widthInfoLabel.Enabled = false;
			heighInfoLabel.Enabled = false;
			minesInfoLabel.Enabled = false;

			widthSelectionTextBox.Enabled = false;
			heightSelectionTextBox.Enabled = false;
			minesSelectionTextBox.Enabled = false;
			mineConstraintsInfoRichTextBox.Enabled = false;
		}

		protected void EnableCustomSelectors()
		{
			widthInfoLabel.Enabled = true;
			heighInfoLabel.Enabled = true;
			minesInfoLabel.Enabled = true;

			widthSelectionTextBox.Enabled = true;
			heightSelectionTextBox.Enabled = true;
			minesSelectionTextBox.Enabled = true;
			mineConstraintsInfoRichTextBox.Enabled = true;
		}

		protected void InitializePresetComboBox()
		{
			presetSelectionComboBox.Items.Add(FieldConfiguration.Beginner.ConfigurationName);
			presetSelectionComboBox.Items.Add(FieldConfiguration.Intermediate.ConfigurationName);
			presetSelectionComboBox.Items.Add(FieldConfiguration.Advanced.ConfigurationName);
			presetSelectionComboBox.Items.Add(FieldConfiguration.CustomConfigString);
			presetSelectionComboBox.SelectedItem = ConfigurationManager.MostRecentFieldConfiguration.ConfigurationName;
		}

		protected void UpdateSelectorValues(string activeConfigName)
		{
			FieldConfiguration config = FieldConfiguration.GetConfigurationByName(activeConfigName);
			if (config != null)
			{
				widthSelectionTextBox.Text = config.Width.ToString();
				heightSelectionTextBox.Text = config.Height.ToString();
				minesSelectionTextBox.Text = config.MinesCount.ToString();
			}
			else
			{
				widthSelectionTextBox.Text = ConfigurationManager.CustomConfigWidth.ToString();
				heightSelectionTextBox.Text = ConfigurationManager.CustomConfigHeight.ToString();
				minesSelectionTextBox.Text = ConfigurationManager.CustomConfigBombs.ToString();
			}
		}

		protected void OnPresetComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox comboBoxSender = sender as ComboBox;
			if (comboBoxSender != null)
			{
				string selectedConfig = comboBoxSender.SelectedItem.ToString();
				if (selectedConfig.CompareTo(FieldConfiguration.CustomConfigString) != 0)
				{
					DisableCustomSelectors();
				}
				else
				{
					EnableCustomSelectors();
				}
				UpdateSelectorValues(comboBoxSender.SelectedItem.ToString());
				SelectedConfig = FieldConfiguration.GetConfigurationByName(selectedConfig);
				if (SelectedConfig == null)
				{
					SelectedConfig = new FieldConfiguration(this.widthSelectionTextBox.Text, this.heightSelectionTextBox.Text, this.minesSelectionTextBox.Text);
				}
			}
		}

		protected bool ValidateSelectorValues(out int width, out int height, out int minesCount)
		{
			width = 0;
			height = 0;
			minesCount = 0;
			bool valuesAreCorrect;

			bool validDataFormat = int.TryParse(widthSelectionTextBox.Text, out width) &&
				int.TryParse(heightSelectionTextBox.Text, out height) &&
				int.TryParse(minesSelectionTextBox.Text, out minesCount);
			if (validDataFormat)
			{
				bool widthIsInRange = width >= 9 && width <= 30;
				bool heightIsInRange = height >= 9 && height <= 24;
				bool minesCountIsInRange = minesCount >= 10 && minesCount <= 0.75 * width * height;

				valuesAreCorrect = widthIsInRange && heightIsInRange && minesCountIsInRange;
			}
			else
			{
				valuesAreCorrect = false;
			}

			return valuesAreCorrect;
		}

		public FieldConfiguration SelectedConfig { get; set; }

		public GameParamsSelectionForm()
		{
			InitializeComponent();
			InitializePresetComboBox();
		}
	}
}
