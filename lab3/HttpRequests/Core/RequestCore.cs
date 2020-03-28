using HttpRequests.Helpers;
using HttpRequests.Interfaces;
using System;
using System.IO;
using System.Net;

namespace HttpRequests.Core
{
	public class RequestCore : IRequestCore
	{
		private WebProxy webProxy;
		private DataHelper dataHelper = new DataHelper();
		private CookieContainer cookieContainer = new CookieContainer();

		public RequestCore()
		{
			if (webProxy == null)
			{
				var cred = new NetworkCredential("username", "password");
				webProxy = new WebProxy("http://address:port/", true, null, cred);
			}
		}

		public void Get(string url)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "GET";
			request.Proxy = webProxy;
			request.CookieContainer = cookieContainer;

			request.BeginGetResponse(new AsyncCallback(result => {
				var response = ((HttpWebRequest)result.AsyncState).EndGetResponse(result) as HttpWebResponse;
				using (Stream dataStream = response.GetResponseStream())
				{
					var reader = new StreamReader(dataStream);
					var responseFromServer = reader.ReadToEnd();
					PrintResponse(responseFromServer);
				}
			}), request);
		}

		public void Post(string url)
		{
			var parameters = dataHelper.AssertPostParameters();
			var postData = dataHelper.ConvertToRequestData(parameters);
			var byteData = dataHelper.ConvertStringToByte(postData);

			var request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "POST";
			request.Proxy = webProxy;
			request.CookieContainer = cookieContainer;
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = byteData.Length;

			Stream requestStream = request.GetRequestStream();
			requestStream.Write(byteData, 0, byteData.Length);
			requestStream.Close();

			request.BeginGetResponse(new AsyncCallback(result => {
				var response = ((HttpWebRequest)result.AsyncState).EndGetResponse(result) as HttpWebResponse;

				using (Stream dataStream = response.GetResponseStream())
				{
					var reader = new StreamReader(dataStream);
					var responseFromServer = reader.ReadToEnd();
					PrintResponse(responseFromServer);
				}
			}), request);
		}

		public void Head(string url)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "HEAD";
			request.Proxy = webProxy;
			request.CookieContainer = cookieContainer;

			request.BeginGetResponse(new AsyncCallback(result => {
				var response = ((HttpWebRequest)result.AsyncState).EndGetResponse(result) as HttpWebResponse;
				PrintResponse(response.Headers.ToString());
			}), request);
		}

		public void Options(string url)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "OPTIONS";
			request.Proxy = webProxy;
			request.CookieContainer = cookieContainer;

			request.BeginGetResponse(new AsyncCallback(result => {
				var response = ((HttpWebRequest)result.AsyncState).EndGetResponse(result) as HttpWebResponse;
				PrintResponse(response.Headers.ToString());
			}), request);
		}

		public void Auth(string url)
		{
			var networkCredential = dataHelper.GetNetworkCredential();

			if (networkCredential == null)
			{
				Console.WriteLine("Invalid authentication.");
				return;
			}

			var request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "GET";
			request.Proxy = webProxy;
			request.Credentials = networkCredential;

			request.BeginGetResponse(new AsyncCallback(result => {
				var response = ((HttpWebRequest)result.AsyncState).EndGetResponse(result) as HttpWebResponse;

				cookieContainer.Add(response.Cookies);
				using (Stream dataStream = response.GetResponseStream())
				{
					var reader = new StreamReader(dataStream);
					var responseFromServer = reader.ReadToEnd();
					PrintResponse(responseFromServer);
				}
			}), request);
		}

		private void PrintResponse(string response)
		{
			Console.WriteLine("\n------ Response ------\n");
			Console.WriteLine(response.Trim());
		}
	}
}
