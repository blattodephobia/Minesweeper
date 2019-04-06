using System.Windows.Forms;
namespace Minesweeper
{
	partial class Confirmation
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
			this.buttonAccept = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelMessage = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonAccept
			// 
			this.buttonAccept.Location = new System.Drawing.Point(68, 107);
			this.buttonAccept.Name = "buttonAccept";
			this.buttonAccept.Size = new System.Drawing.Size(89, 23);
			this.buttonAccept.TabIndex = 0;
			this.buttonAccept.Text = "OK";
			this.buttonAccept.UseVisualStyleBackColor = true;
			this.buttonAccept.Click += new System.EventHandler(this.OnAccept);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(163, 107);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(89, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.OnCancel);
			// 
			// labelMessage
			// 
			this.labelMessage.Location = new System.Drawing.Point(12, 13);
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Size = new System.Drawing.Size(281, 77);
			this.labelMessage.TabIndex = 2;
			// 
			// Confirmation
			// 
			this.AcceptButton = this.buttonAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(305, 142);
			this.Controls.Add(this.labelMessage);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonAccept);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Confirmation";
			this.ShowInTaskbar = false;
			this.Text = "Confirmation";
			this.ResumeLayout(false);

		}

		void AutoPositionButtons(Button accept, Button cancel)
		{
			int acceptButtonX, cancelButtonX;
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

		private System.Windows.Forms.Button buttonAccept;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelMessage;
	}
}