using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Minesweeper
{
	public partial class AboutDialog : Form
	{
		public AboutDialog()
		{
			InitializeComponent();
			NormalizeLayout();
		}

		private void OnAcceptButtonClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
