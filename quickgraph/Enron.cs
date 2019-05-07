using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using QuickGraph;
using QuickGraph.Algorithms.Search;
using QuickGraph.Algorithms.Observers;

namespace quickgraph
{
	class Enron
	{
		public const string path = "../../../samples/Email-Enron.txt";
		public const bool avoidDoubles = true;
		public static readonly int[] indexes = { 100, 1000, 10000 };

		private static Graph graph;

		private static List<int> vertices;
		private static List<int[]> edges;

		private static Stopwatch watch;
		private static TimeSpan span;
		private static string elapsedTime;

		public static void Run()
		{
			vertices = new List<int>();
			edges = new List<int[]>();

			watch = new Stopwatch();

			try
			{
				Prepare();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return;
			}

			graph = new Graph();

			watch.Restart();

			foreach (int vertex in vertices)
			{
				graph.AddVertex(vertex);
			}

			foreach (int[] edge in edges)
			{
				graph.AddEdge(new Edge(edge[0], edge[1]));
			}

			watch.Stop();

			span = watch.Elapsed;
			elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", span.Hours, span.Minutes, span.Seconds, span.Milliseconds / 10);

			Console.WriteLine("Loading done.");

			Console.WriteLine("Loading time: " + elapsedTime);

			Console.WriteLine("Vertices: " + graph.VertexCount);
			Console.WriteLine("Edges: " + graph.EdgeCount);

			BFS();
			DFS();
		}

		private static void Prepare()
		{
			string line;
			string[] strSplited;
			int[] splited;

			Console.WriteLine("Preparing...");

			System.IO.StreamReader file = new System.IO.StreamReader(path);

			if (avoidDoubles)
			{
				while ((line = file.ReadLine()) != null)
				{
					strSplited = line.Split('\t');
					splited = new int[] { Int32.Parse(strSplited[0]), Int32.Parse(strSplited[1]) };

					if (splited[0] < splited[1])
					{
						vertices.Add(splited[0]);
						vertices.Add(splited[1]);
						edges.Add(splited);
					}
				}
			}
			else
			{
				while ((line = file.ReadLine()) != null)
				{
					strSplited = line.Split('\t');
					splited = new int[] { Int32.Parse(strSplited[0]), Int32.Parse(strSplited[1]) };

					vertices.Add(splited[0]);
					vertices.Add(splited[1]);
					edges.Add(splited);
				}
			}

			List<int> distinct = vertices.Distinct().ToList();
			vertices = distinct;

			Console.WriteLine("Unique vertices: " + vertices.Count);

			Console.WriteLine("Preparing done.");

			file.Close();
		}

		private static void BFS()
		{
			watch.Restart();

			var found = new List<int>();
			var bfs = new UndirectedBreadthFirstSearchAlgorithm<int, Edge>(graph);

			bfs.DiscoverVertex += v => found.Add(v);
			bfs.Compute(0);

			watch.Stop();

			span = watch.Elapsed;
			elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", span.Hours, span.Minutes, span.Seconds, span.Milliseconds / 10);

			Console.WriteLine("BFS time: " + elapsedTime);
			Console.WriteLine("BFS elements: " + found.Count);

			foreach (int index in indexes)
			{
				Console.WriteLine(index + ": " + found[index]);
			}
		}

		private static void DFS()
		{
			watch.Restart();

			var found = new List<int>();
			var dfs = new UndirectedDepthFirstSearchAlgorithm<int, Edge>(graph);

			dfs.DiscoverVertex += v => found.Add(v);
			dfs.Compute(0);

			watch.Stop();

			span = watch.Elapsed;
			elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", span.Hours, span.Minutes, span.Seconds, span.Milliseconds / 10);

			Console.WriteLine("DFS time: " + elapsedTime);
			Console.WriteLine("DFS elements: " + found.Count);

			foreach (int index in indexes)
			{
				Console.WriteLine(index + ": " + found[index]);
			}
		}
	}
}