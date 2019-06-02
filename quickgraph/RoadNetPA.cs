namespace quickgraph
{
	class RoadNetPA : Core
	{
		public RoadNetPA()
		{
			path = "../../../samples/roadNet-PA.txt";
			avoidDoubles = true;
			uniqueTests = new int[] { 100, 1000, 10000 };
			indexes = new int[] { 100, 1000, 10000, 100000 };
			algorithms = new string[] { "bfs", "dfs", "shortest" };
		}
	}
}