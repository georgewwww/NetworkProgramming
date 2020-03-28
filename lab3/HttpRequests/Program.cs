using HttpRequests.Core;
using System;

namespace HttpRequests
{
	class Program
	{
		/* Some examples for requests
		 * 1. https://jsonplaceholder.typicode.com/
		 * 2. https://docs.postman-echo.com/
		 * */

		static void Main(string[] args)
		{
			var request = new RequestCore();

			Console.Write("enter url: ");
			var url = Console.ReadLine();
			Console.WriteLine("1. get\n2. post\n3. head\n4. options\n5. auth\n\n9. change url");

			while (true)
			{
				var option = Convert.ToInt32(Console.ReadLine());
				Console.Clear();

				switch (option)
				{
					case 1:
						request.Get(url);
						break;
					case 2:
						request.Post(url);
						break;
					case 3:
						request.Head(url);
						break;
					case 4:
						request.Options(url);
						break;
					case 5:
						request.Auth(url);
						break;
					case 9:
						Console.Write("enter url: ");
						url = Console.ReadLine();
						break;
					default:
						return;
				}
			}
		}
	}
}
