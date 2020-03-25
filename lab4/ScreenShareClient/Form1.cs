using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace ScreenShareClient
{
	public partial class Form1 : Form
	{
		private readonly TcpClient client = new TcpClient();
		private NetworkStream mainStream;
		private int port;

		private float scalingFactor;

		private Image GrabDesktop()
		{
			Rectangle bounds = Screen.PrimaryScreen.Bounds;
			bounds.Width = Convert.ToInt32(bounds.Width * scalingFactor);
			bounds.Height = Convert.ToInt32(bounds.Height * scalingFactor);
			Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
			Graphics graphic = Graphics.FromImage(screenshot);
			graphic.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);

			Console.WriteLine(screenshot.Width + "x" + screenshot.Height);
			return screenshot;
		}

		private void SendDesktopImage()
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			mainStream = client.GetStream();
			binaryFormatter.Serialize(mainStream, GrabDesktop());
		}

		public Form1()
		{
			InitializeComponent();
			scalingFactor = getScalingFactor();
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			port = int.Parse(txtPort.Text);
			try
			{
				client.Connect(txtIp.Text, port);
				MessageBox.Show("Connected");
			}
			catch (Exception)
			{
				MessageBox.Show("Failed to connect...");
			}
		}

		private void btnShare_Click(object sender, EventArgs e)
		{
			if (btnShare.Text.StartsWith("Share"))
			{
				timer1.Start();
				btnShare.Text = "Stop Sharing";
			} else
			{
				timer1.Stop();
				btnShare.Text = "Share My Screen";
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			SendDesktopImage();
		}

		#region Methods to get screen scaling factor
		[DllImport("gdi32.dll")]
		static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
		public enum DeviceCap
		{
			VERTRES = 10,
			DESKTOPVERTRES = 117
		}

		private float getScalingFactor()
		{
			Graphics g = Graphics.FromHwnd(IntPtr.Zero);
			IntPtr desktop = g.GetHdc();
			int LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
			int PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);

			float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;

			return ScreenScalingFactor; // 1.25 = 125%
		}
		#endregion
	}
}
