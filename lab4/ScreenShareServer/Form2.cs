using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace ScreenShareServer
{
	public partial class Form2 : Form
	{
		private readonly int port;
		private TcpClient client;
		private TcpListener server;
		private NetworkStream mainStream;

		private readonly Thread Listening;
		private readonly Thread GetImage;

		public Form2(int Port)
		{
			port = Port;
			client = new TcpClient();
			Listening = new Thread(StartListening);
			GetImage = new Thread(RecieveImage);
			InitializeComponent();
		}

		private void StartListening()
		{
			while(!client.Connected)
			{
				server.Start();
				client = server.AcceptTcpClient();
			}
			GetImage.Start();
		}

		private void RecieveImage()
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			while (client.Connected)
			{
				mainStream = client.GetStream();
				pictureBox1.Image = (Image) binaryFormatter.Deserialize(mainStream);
			}
		}

		private void StopListening()
		{
			server.Stop();
			client = null;
			if (Listening.IsAlive) Listening.Abort();
			if (GetImage.IsAlive) GetImage.Abort();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			server = new TcpListener(IPAddress.Any, port);
			Listening.Start();
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			StopListening();
			base.OnFormClosing(e);
		}
	}
}
