using System;
using System.Windows.Forms;

namespace Client
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			LoginForm loginForm = new LoginForm();
			Application.Run(loginForm);
			if (loginForm.DialogResult == DialogResult.OK)
			{
				UserForm clientForm = new UserForm();
				clientForm.clientSocket = loginForm.clientSocket;
				clientForm.userName = loginForm.userName;
				clientForm.server = loginForm.epServer;

				clientForm.ShowDialog();
			}
		}
	}
}
