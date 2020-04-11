using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
	public class Data
	{
		public string userName;
		public string strMessage;
		public Command cmdCommand;

		public Data()
		{
			this.cmdCommand = Command.Null;
			this.strMessage = null;
			this.userName = null;
		}

		public Data(byte[] data)
		{
			this.cmdCommand = (Command)BitConverter.ToInt32(data, 0);

			int nameLen = BitConverter.ToInt32(data, 4);

			int msgLen = BitConverter.ToInt32(data, 8);

			if (nameLen > 0)
				this.userName = Encoding.UTF8.GetString(data, 12, nameLen);
			else
				this.userName = null;

			if (msgLen > 0)
				this.strMessage = Encoding.UTF8.GetString(data, 12 + nameLen, msgLen);
			else
				this.strMessage = null;
		}

		public byte[] ToByte()
		{
			List<byte> result = new List<byte>();

			result.AddRange(BitConverter.GetBytes((int)cmdCommand));

			if (userName != null)
				result.AddRange(BitConverter.GetBytes(userName.Length));
			else
				result.AddRange(BitConverter.GetBytes(0));

			if (strMessage != null)
				result.AddRange(BitConverter.GetBytes(strMessage.Length));
			else
				result.AddRange(BitConverter.GetBytes(0));

			if (userName != null)
				result.AddRange(Encoding.UTF8.GetBytes(userName));

			if (strMessage != null)
				result.AddRange(Encoding.UTF8.GetBytes(strMessage));

			return result.ToArray();
		}
	}
}
