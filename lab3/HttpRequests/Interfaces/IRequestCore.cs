namespace HttpRequests.Interfaces
{
	interface IRequestCore
	{
		void Get(string url);
		void Post(string url);
		void Head(string url);
		void Options(string url);
		void Auth(string url);
	}
}
