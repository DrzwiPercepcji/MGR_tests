namespace quickgraph
{
	class Enron : Core
	{
		public Enron()
		{
			path = "../../../samples/Email-Enron.txt";
			avoidDoubles = true;
			uniqueTests = new int[] { 100, 1000, 10000 };
			indexes = new int[] { 100, 1000, 10000 };
			algorithms = new string[] { "bfs", "dfs", "shortest" };
		}
	}
}