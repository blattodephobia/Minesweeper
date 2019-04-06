using Minesweeper.Resources;
namespace Minesweeper
{
	partial class AboutDialog
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
			this.labelAbout = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelAbout
			// 
			this.labelAbout.Location = new System.Drawing.Point(12, 12);
			this.labelAbout.Name = "labelAbout";
			this.labelAbout.Size = new System.Drawing.Size(307, 65);
			this.labelAbout.TabIndex = 0;
			this.labelAbout.Text = "Created by Ivan Nenchovski.\r\nSpecial thanks go out to my computer, my HIDs and al" +
				"l the sunflower seed shells under my desk.";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button1.Location = new System.Drawing.Point(124, 94);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.OnAcceptButtonClick);
			// 
			// AboutDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(331, 129);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.labelAbout);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			this.ResumeLayout(false);

		}

		private void NormalizeLayout()
		{
			this.button1.Location = new System.Drawing.Point((this.Size.Width - this.button1.Width) / 2, this.button1.Location.Y);
		}

		#endregion

		private System.Windows.Forms.Label labelAbout;
		private System.Windows.Forms.Button button1;
	}
}