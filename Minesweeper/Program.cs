using System;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;

namespace Minesweeper
{
	public static class ProgramMainEntryPoint
	{
		private static readonly string mutexName = "Insectophobia.Minesweeper.Instance";
		private static Mutex instanceMutex;
		private static bool InstanceActive
		{
			get
			{
				try
				{
					instanceMutex = Mutex.OpenExisting(mutexName);
				}
				catch (WaitHandleCannotBeOpenedException)
				{
					return false;
				}

				return instanceMutex != null;
			}

			set
			{
				if (!InstanceActive && value)
				{
					instanceMutex = new Mutex(true, mutexName);
				}
				else if (InstanceActive && !value)
				{
					instanceMutex.Close();
				}
			}
		}
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				if (!InstanceActive)
				{
					InstanceActive = true;
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Form mainForm = new MinesweeperMain();
					mainForm.FormClosed += new FormClosedEventHandler(OnMainFormClosed);
					Application.Run(mainForm);
				}
			}
			finally
			{
			}
		}

		static void OnMainFormClosed(object sender, FormClosedEventArgs e)
		{
			if (InstanceActive)
			{
				InstanceActive = false;
			}
		}
	}
}
