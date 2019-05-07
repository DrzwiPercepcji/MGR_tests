using System;
using QuickGraph;
using QuickGraph.Algorithms.ShortestPath;

/*
* Source: https://danielbrannstrom.wordpress.com/2011/09/09/quickgraph/
*/

namespace quickgraph
{
	class Edge : IEdge<int>
	{
		public Edge(int s, int t, int w = 1)
		{
			Source = s;
			Target = t;
			Weight = w;
		}

		public int Source { get; set; }

		public int Target { get; set; }

		public int Weight { get; set; }
	}

	class Graph : UndirectedGraph<int, Edge> { }

	class Example
	{
		public static void Run()
		{
			int[,] data = new int[,]
				{{131, 673, 234, 103, 18},
				{201, 96, 342, 965, 150},
				{630, 803, 746, 422, 111},
				{537, 699, 497, 121, 956},
				{805, 732, 524, 37, 331}};

			int size = data.GetLength(0);

			Graph g = new Graph();

			for (int v = 0; v < size * size; v++)
				g.AddVertex(v);

			for (int i = 0; i < size - 1; i++)
			{
				for (int j = 0; j < size - 1; j++)
				{
					g.AddEdge(new Edge(i + size * j, i + 1 + size * j, data[j, i + 1]));
					g.AddEdge(new Edge(i + size * j, i + size * (j + 1), data[j + 1, i]));
				}
			}

			int lastw = data[size - 1, size - 1];
			int lasti = size * size - 1;

			g.AddEdge(new Edge(lasti - 1, lasti, lastw));
			g.AddEdge(new Edge(lasti - size, lasti, lastw));

			/*
			var dijkstra = new DijkstraShortestPathAlgorithm<int, Edge>(g, e => (double)e.Weight);

			dijkstra.Compute(0);

			double result = dijkstra.Distances[g.VertexCount - 1];

			result += data[0, 0];

			Console.WriteLine("Result is : " + result);
			*/
		}
	}
}