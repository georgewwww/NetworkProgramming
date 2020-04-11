using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client
{
	public partial class LoginForm : Form
	{
		public Socket clientSocket;
		public EndPoint epServer;
		public string userName;

		public LoginForm()
		{
			InitializeComponent();
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			userName = txtUsername.Text;
			try
			{
				clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

				IPAddress ipAddress = IPAddress.Parse(txtIp.Text);
				IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 1000);

				epServer = ipEndPoint;

				Data msgToSend = new Data
				{
					cmdCommand = Command.Login,
					strMessage = null,
					userName = userName
				};

				byte[] byteData = msgToSend.ToByte();

				clientSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, epServer, new AsyncCallback(OnSend), null);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Client",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void OnSend(IAsyncResult ar)
		{
			try
			{
				clientSocket.EndSend(ar);
				userName = txtUsername.Text;
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void LoginForm_Load(object sender, EventArgs e)
		{
			CheckForIllegalCrossThreadCalls = false;
		}

		private void txtUsername_TextChanged(object sender, EventArgs e)
		{
			if (txtUsername.Text.Length > 0 && txtIp.Text.Length > 0)
				btnConnect.Enabled = true;
			else
				btnConnect.Enabled = false;
		}

		private void txtIp_TextChanged(object sender, EventArgs e)
		{
			if (txtUsername.Text.Length > 0 && txtIp.Text.Length > 0)
				btnConnect.Enabled = true;
			else
				btnConnect.Enabled = false;
		}
	}
}
