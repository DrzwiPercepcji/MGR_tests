using System;

namespace quickgraph
{
	class App
	{
		static void Main(string[] args)
		{
			string input = Console.ReadLine();
			Core instance;

			switch (input)
			{
				case "Test":
					instance = new Test();
					instance.Run();
					break;

				case "RoadNetPA":
					instance = new RoadNetPA();
					instance.Run();
					break;

				case "Enron":
					instance = new Enron();
					instance.Run();
					break;
			}

			Console.ReadKey();
			System.Environment.Exit(1);
		}
	}
}
