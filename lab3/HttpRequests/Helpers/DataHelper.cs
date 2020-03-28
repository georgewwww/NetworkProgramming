using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;

namespace HttpRequests.Helpers
{
	public class DataHelper
	{
		public Dictionary<string, string> AssertPostParameters()
		{
			var parameters = new Dictionary<string, string>();

			Console.WriteLine("\n------ Reading Post Parameters ------\n(write exit to end writing)");
			var key = string.Empty;
			var value = string.Empty;
			while (true)
			{
				Console.Write("key: ");
				key = Console.ReadLine();
				if (key == "exit") break;
				Console.Write("value: ");
				value = Console.ReadLine();
				parameters.Add(key, value);
			}

			return parameters;
		}

		public string ConvertToRequestData(Dictionary<string, string> parameters)
		{
			var postData = string.Empty;
			foreach (string key in parameters.Keys)
			{
				postData += HttpUtility.UrlEncode(key) + "="
					  + HttpUtility.UrlEncode(parameters[key]) + "&";
			}
			return postData;
		}

		public byte[] ConvertStringToByte(string data)
		{
			return Encoding.ASCII.GetBytes(data);
		}

		public NetworkCredential GetNetworkCredential()
		{
			Console.WriteLine("\n------ Insert Auth Credentials ------");
			Console.Write("username: ");
			var username = Console.ReadLine();
			Console.Write("password: ");
			var password = Console.ReadLine();

			if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
			{
				return new NetworkCredential(username, password);
			}
			return null;
		}
	}
}
