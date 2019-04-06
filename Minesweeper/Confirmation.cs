using System.Windows.Forms;

namespace Minesweeper
{
	public partial class Confirmation : Form
	{
		public Confirmation()
		{
			InitializeComponent();
		}

		public Confirmation(string message)
		{
			InitializeComponent();
			this.labelMessage.Text = message;
		}
	}
}
