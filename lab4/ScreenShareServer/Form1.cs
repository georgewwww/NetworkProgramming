using System;
using System.Windows.Forms;

namespace ScreenShareServer
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnListen_Click(object sender, EventArgs e)
		{
			new Form2(int.Parse(txtPort.Text)).Show();
		}
	}
}
