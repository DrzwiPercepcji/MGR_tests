using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.Search;
using QuickGraph.Algorithms.Observers;
using QuickGraph.Algorithms.ShortestPath;

namespace quickgraph
{
	abstract class Core
	{
		protected string path;
		protected bool avoidDoubles;
		protected int[] uniqueTests;
		protected int[] indexes;
		protected string[] algorithms;

		private Graph graph;

		private List<int> vertices;
		private List<int[]> edges;

		private Stopwatch watch;
		private TimeSpan span;
		private string elapsedTime;

		public void Run()
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

			if (algorithms.Contains("bfs"))
			{
				BFS();
			}

			if (algorithms.Contains("dfs"))
			{
				DFS();
			}

			if (algorithms.Contains("shortest"))
			{
				Shortest();
			}
		}

		private void Prepare()
		{
			string line;
			string[] strSplited;
			int[] splited;
			int lines = 0;

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

					lines++;
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

					lines++;
				}
			}

			Console.WriteLine("Lines: " + lines);

			List<int> distinct = vertices.Distinct().ToList();
			vertices = distinct;

			Console.WriteLine("Unique vertices: " + vertices.Count);

			foreach (int index in uniqueTests)
			{
				Console.WriteLine("Unique " + index + ": " + vertices[index]);
			}

			Console.WriteLine("Preparing done.");

			file.Close();
		}

		private void BFS()
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

		private void DFS()
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

		private void Shortest()
		{
			watch.Restart();

			var found = new List<Edge>();
			Func<Edge, double> edgeCost = e => 1;
			TryFunc<int, IEnumerable<Edge>> tryGetPaths = graph.ShortestPathsDijkstra(edgeCost, 0);

			IEnumerable<Edge> path;
			if (tryGetPaths(10000, out path))
			{
				foreach (var edge in path)
				{
					found.Add(edge);
				}
			}

			watch.Stop();

			span = watch.Elapsed;
			elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", span.Hours, span.Minutes, span.Seconds, span.Milliseconds / 10);

			Console.WriteLine("Shortest time: " + elapsedTime);
			Console.WriteLine("Shortest elements: " + found.Count);
		}
	}
}