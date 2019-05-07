using System;

namespace quickgraph
{
	class Test
	{
		static void Main(string[] args)
		{
			string input = Console.ReadLine();

			switch (input)
			{
				case "Example":
					Example.Run();
					break;

				case "RoadNetPA":
					RoadNetPA.Run();
					break;

				case "Enron":
					Enron.Run();
					break;
			}

			Console.ReadKey();
			System.Environment.Exit(1);
		}
	}
}