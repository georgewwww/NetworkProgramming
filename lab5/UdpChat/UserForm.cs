using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client
{
	public enum Command
	{
		Login,
		Logout,
		Message,
		List,
		Null
	}

	public partial class UserForm : Form
	{
		public Socket clientSocket;
		public string userName;
		public EndPoint server;

		byte[] byteData = new byte[1024];

		public UserForm()
		{
			InitializeComponent();
		}

		private void Client_Load(object sender, EventArgs e)
		{
			CheckForIllegalCrossThreadCalls = false;

			this.Text = "Client: " + userName;

			Data msgToSend = new Data
			{
				cmdCommand = Command.List,
				userName = userName,
				strMessage = null
			};

			byteData = msgToSend.ToByte();

			clientSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, server,
				new AsyncCallback(OnSend), null);

			byteData = new byte[1024];
			clientSocket.BeginReceiveFrom(byteData,
				0, byteData.Length,
				SocketFlags.None,
				ref server,
				new AsyncCallback(OnReceive),
				null);
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(txtMessage.Text))
				{
					return;
				}
				Data msgToSend = new Data
				{
					userName = userName,
					strMessage = txtMessage.Text,
					cmdCommand = Command.Message
				};

				byte[] byteData = msgToSend.ToByte();

				clientSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, server, new AsyncCallback(OnSend), null);

				txtMessage.Text = string.Empty;
			}
			catch (Exception)
			{
				MessageBox.Show("An error occured while sending the message.", "Client: " + userName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void OnSend(IAsyncResult ar)
		{
			try
			{
				clientSocket.EndSend(ar);
			}
			catch (ObjectDisposedException)
			{ }
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Client: " + userName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void OnReceive(IAsyncResult ar)
		{
			try
			{
				clientSocket.EndReceive(ar);

				Data msgReceived = new Data(byteData);

				switch (msgReceived.cmdCommand)
				{
					case Command.Login:
						lstChatters.Items.Add(msgReceived.userName);
						break;

					case Command.Message:
						break;

					case Command.Logout:
						lstChatters.Items.Remove(msgReceived.userName);
						break;

					case Command.List:
						lstChatters.Items.AddRange(msgReceived.strMessage.Split('*'));
						lstChatters.Items.RemoveAt(lstChatters.Items.Count - 1);
						txtChatBox.Text += "[+] " + userName + " has joined the room.\r\n";
						break;
				}

				if (msgReceived.strMessage != null && msgReceived.cmdCommand != Command.List)
					txtChatBox.Text += msgReceived.strMessage + "\r\n";

				byteData = new byte[1024];

				clientSocket.BeginReceiveFrom(byteData, 0, byteData.Length, SocketFlags.None, ref server,
					new AsyncCallback(OnReceive), null);
			}
			catch (ObjectDisposedException)
			{ }
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Client: " + userName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void txtMessage_TextChanged(object sender, EventArgs e)
		{
			if (txtMessage.Text.Length == 0)
				btnSend.Enabled = false;
			else
				btnSend.Enabled = true;
		}

		private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to leave the chat room?", "Client: " + userName,
				MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
			{
				e.Cancel = true;
				return;
			}

			try
			{
				Data msgToSend = new Data
				{
					cmdCommand = Command.Logout,
					userName = userName,
					strMessage = null
				};

				byte[] b = msgToSend.ToByte();
				clientSocket.SendTo(b, 0, b.Length, SocketFlags.None, server);
				clientSocket.Close();
			}
			catch (ObjectDisposedException)
			{ }
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Client: " + userName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Return)
			{
				btnSend_Click(sender, e);
			}
		}
	}
}
