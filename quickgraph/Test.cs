namespace quickgraph
{
	class Test : Core
	{
		public Test()
		{
			path = "../../../samples/test2.txt";
			avoidDoubles = true;
			uniqueTests = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			indexes = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			algorithms = new string[] { "bfs", "dfs" };
		}
	}
}