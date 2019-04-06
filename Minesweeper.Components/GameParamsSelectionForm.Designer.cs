namespace Minesweeper.Components
{
	partial class GameParamsSelectionForm
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
			this.presetSelectionComboBox = new System.Windows.Forms.ComboBox();
			this.widthInfoLabel = new System.Windows.Forms.Label();
			this.heighInfoLabel = new System.Windows.Forms.Label();
			this.minesInfoLabel = new System.Windows.Forms.Label();
			this.configAccept = new System.Windows.Forms.Button();
			this.configCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.mineConstraintsInfoRichTextBox = new System.Windows.Forms.RichTextBox();
			this.widthSelectionTextBox = new System.Windows.Forms.TextBox();
			this.heightSelectionTextBox = new System.Windows.Forms.TextBox();
			this.minesSelectionTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// presetSelectionComboBox
			// 
			this.presetSelectionComboBox.FormattingEnabled = true;
			this.presetSelectionComboBox.Location = new System.Drawing.Point(12, 45);
			this.presetSelectionComboBox.Name = "presetSelectionComboBox";
			this.presetSelectionComboBox.Size = new System.Drawing.Size(126, 21);
			this.presetSelectionComboBox.TabIndex = 0;
			this.presetSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.OnPresetComboBoxSelectedIndexChanged);
			// 
			// widthInfoLabel
			// 
			this.widthInfoLabel.AutoSize = true;
			this.widthInfoLabel.Location = new System.Drawing.Point(163, 48);
			this.widthInfoLabel.Name = "widthInfoLabel";
			this.widthInfoLabel.Size = new System.Drawing.Size(68, 13);
			this.widthInfoLabel.TabIndex = 7;
			this.widthInfoLabel.Text = "Width (9-30):";
			this.widthInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// heighInfoLabel
			// 
			this.heighInfoLabel.AutoSize = true;
			this.heighInfoLabel.Location = new System.Drawing.Point(163, 75);
			this.heighInfoLabel.Name = "heighInfoLabel";
			this.heighInfoLabel.Size = new System.Drawing.Size(71, 13);
			this.heighInfoLabel.TabIndex = 8;
			this.heighInfoLabel.Text = "Height (9-24):";
			this.heighInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// minesInfoLabel
			// 
			this.minesInfoLabel.AutoSize = true;
			this.minesInfoLabel.Location = new System.Drawing.Point(163, 102);
			this.minesInfoLabel.Name = "minesInfoLabel";
			this.minesInfoLabel.Size = new System.Drawing.Size(80, 13);
			this.minesInfoLabel.TabIndex = 9;
			this.minesInfoLabel.Text = "Mines (10-540):";
			this.minesInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// configAccept
			// 
			this.configAccept.Location = new System.Drawing.Point(76, 175);
			this.configAccept.Name = "configAccept";
			this.configAccept.Size = new System.Drawing.Size(86, 23);
			this.configAccept.TabIndex = 10;
			this.configAccept.Text = "OK";
			this.configAccept.UseVisualStyleBackColor = true;
			this.configAccept.Click += new System.EventHandler(this.OnAccept);
			// 
			// configCancel
			// 
			this.configCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.configCancel.Location = new System.Drawing.Point(178, 175);
			this.configCancel.Name = "configCancel";
			this.configCancel.Size = new System.Drawing.Size(86, 23);
			this.configCancel.TabIndex = 11;
			this.configCancel.Text = "Cancel";
			this.configCancel.UseVisualStyleBackColor = true;
			this.configCancel.Click += new System.EventHandler(this.OnCancel);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(251, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Choose a preset or custom game field configuration:";
			// 
			// mineConstraintsInfoRichTextBox
			// 
			this.mineConstraintsInfoRichTextBox.BackColor = System.Drawing.SystemColors.Control;
			this.mineConstraintsInfoRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.mineConstraintsInfoRichTextBox.Location = new System.Drawing.Point(12, 134);
			this.mineConstraintsInfoRichTextBox.Name = "mineConstraintsInfoRichTextBox";
			this.mineConstraintsInfoRichTextBox.Size = new System.Drawing.Size(316, 26);
			this.mineConstraintsInfoRichTextBox.TabIndex = 13;
			this.mineConstraintsInfoRichTextBox.Text = "Note that the mines count must be between 10 and 75% of the available squares on " +
				"the field.";
			// 
			// widthSelectionTextBox
			// 
			this.widthSelectionTextBox.Location = new System.Drawing.Point(246, 45);
			this.widthSelectionTextBox.Name = "widthSelectionTextBox";
			this.widthSelectionTextBox.Size = new System.Drawing.Size(82, 20);
			this.widthSelectionTextBox.TabIndex = 14;
			this.widthSelectionTextBox.Text = "\r\n";
			this.widthSelectionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// heightSelectionTextBox
			// 
			this.heightSelectionTextBox.Location = new System.Drawing.Point(246, 73);
			this.heightSelectionTextBox.Name = "heightSelectionTextBox";
			this.heightSelectionTextBox.Size = new System.Drawing.Size(82, 20);
			this.heightSelectionTextBox.TabIndex = 15;
			this.heightSelectionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// minesSelectionTextBox
			// 
			this.minesSelectionTextBox.Location = new System.Drawing.Point(246, 100);
			this.minesSelectionTextBox.Name = "minesSelectionTextBox";
			this.minesSelectionTextBox.Size = new System.Drawing.Size(82, 20);
			this.minesSelectionTextBox.TabIndex = 16;
			this.minesSelectionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// GameParamsSelectionForm
			// 
			this.AcceptButton = this.configAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.configCancel;
			this.ClientSize = new System.Drawing.Size(340, 208);
			this.Controls.Add(this.minesSelectionTextBox);
			this.Controls.Add(this.heightSelectionTextBox);
			this.Controls.Add(this.widthSelectionTextBox);
			this.Controls.Add(this.mineConstraintsInfoRichTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.configCancel);
			this.Controls.Add(this.configAccept);
			this.Controls.Add(this.minesInfoLabel);
			this.Controls.Add(this.heighInfoLabel);
			this.Controls.Add(this.widthInfoLabel);
			this.Controls.Add(this.presetSelectionComboBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GameParamsSelectionForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Create Game Field";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		void OnClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
			if (DialogResult == System.Windows.Forms.DialogResult.OK)
			{
				SelectedConfig = FieldConfiguration.GetConfigurationByName(this.presetSelectionComboBox.SelectedItem.ToString());
				if (SelectedConfig == null)
				{
					SelectedConfig = new FieldConfiguration(this.widthSelectionTextBox.Text, this.heightSelectionTextBox.Text, this.minesSelectionTextBox.Text);
				}
				ConfigurationManager.MostRecentFieldConfiguration = SelectedConfig;
			}
		}

		void OnCancel(object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		void OnAccept(object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		#endregion

		private System.Windows.Forms.ComboBox presetSelectionComboBox;
		private System.Windows.Forms.Label widthInfoLabel;
		private System.Windows.Forms.Label heighInfoLabel;
		private System.Windows.Forms.Label minesInfoLabel;
		private System.Windows.Forms.Button configAccept;
		private System.Windows.Forms.Button configCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox mineConstraintsInfoRichTextBox;
		private System.Windows.Forms.TextBox widthSelectionTextBox;
		private System.Windows.Forms.TextBox heightSelectionTextBox;
		private System.Windows.Forms.TextBox minesSelectionTextBox;
	}
}