using Client;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Server
{
	public partial class Server : Form
	{
		struct ClientInfo
		{
			public EndPoint endpoint;
			public string UserName;
		}

		ArrayList clientList;
		Socket serverSocket;
		byte[] byteData = new byte[1024];

		public Server()
		{
			clientList = new ArrayList();
			InitializeComponent();
		}

		private void Server_Load(object sender, EventArgs e)
		{
			try
			{
				CheckForIllegalCrossThreadCalls = false;

				serverSocket = new Socket(AddressFamily.InterNetwork,
					SocketType.Dgram, ProtocolType.Udp);

				IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 1000);

				serverSocket.Bind(ipEndPoint);

				IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 0);
				EndPoint epSender = ipeSender;

				serverSocket.BeginReceiveFrom(byteData, 0, byteData.Length,
					SocketFlags.None, ref epSender, new AsyncCallback(OnReceive), epSender);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Server",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void OnReceive(IAsyncResult ar)
		{
			try
			{
				IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 0);
				EndPoint epSender = ipeSender;

				serverSocket.EndReceiveFrom(ar, ref epSender);

				Data msgReceived = new Data(byteData);

				byte[] message;

				Data msgToSend = new Data
				{
					cmdCommand = msgReceived.cmdCommand,
					userName = msgReceived.userName
				};

				switch (msgReceived.cmdCommand)
				{
					case Command.Login:

						ClientInfo clientInfo = new ClientInfo
						{
							endpoint = epSender,
							UserName = msgReceived.userName
						};

						clientList.Add(clientInfo);

						msgToSend.strMessage = "[+] " + msgReceived.userName + " has joined the room.";
						break;

					case Command.Logout:

						int nIndex = 0;
						foreach (ClientInfo client in clientList)
						{
							if (client.endpoint.Equals(epSender))
							{
								clientList.RemoveAt(nIndex);
								break;
							}
							++nIndex;
						}

						msgToSend.strMessage = "[-] " + msgReceived.userName + " has left the room.";
						break;

					case Command.Message:
						msgToSend.strMessage = msgReceived.userName + ": " + msgReceived.strMessage;
						break;

					case Command.List:
						msgToSend.cmdCommand = Command.List;
						msgToSend.userName = null;
						msgToSend.strMessage = null;

						foreach (ClientInfo client in clientList)
						{
							msgToSend.strMessage += client.UserName + "*";
						}

						message = msgToSend.ToByte();

						serverSocket.BeginSendTo(message, 0, message.Length, SocketFlags.None, epSender,
								new AsyncCallback(OnSend), epSender);
						break;
				}

				if (msgToSend.cmdCommand != Command.List)
				{
					message = msgToSend.ToByte();

					foreach (ClientInfo clientInfo in clientList)
					{
						if (clientInfo.endpoint != epSender ||
							msgToSend.cmdCommand != Command.Login)
						{
							serverSocket.BeginSendTo(message, 0, message.Length, SocketFlags.None, clientInfo.endpoint,
								new AsyncCallback(OnSend), clientInfo.endpoint);
						}
					}

					txtUsers.Text += msgToSend.strMessage + "\r\n";
				}
				if (msgReceived.cmdCommand != Command.Logout)
				{
					serverSocket.BeginReceiveFrom(byteData, 0, byteData.Length, SocketFlags.None, ref epSender,
						new AsyncCallback(OnReceive), epSender);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void OnSend(IAsyncResult ar)
		{
			try
			{
				serverSocket.EndSend(ar);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
