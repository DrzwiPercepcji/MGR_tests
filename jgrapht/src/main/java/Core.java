import org.jgrapht.Graph;
import org.jgrapht.GraphPath;
import org.jgrapht.alg.shortestpath.DijkstraShortestPath;
import org.jgrapht.graph.DefaultEdge;
import org.jgrapht.graph.DefaultUndirectedGraph;
import org.jgrapht.traverse.BreadthFirstIterator;
import org.jgrapht.traverse.DepthFirstIterator;
import org.jgrapht.traverse.GraphIterator;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.List;

public abstract class Core {

    public static void run(String path, Boolean avoidDoubles, Integer[] uniqueTests, Integer[] indexes, String[] algorithms) {

        long startTime;
        long endTime;

        Graph<String, DefaultEdge> graph = new DefaultUndirectedGraph<>(DefaultEdge.class);

        System.out.println("Preparing...");

        ArrayList<String> vertices = new ArrayList<>();
        ArrayList<String[]> edges = new ArrayList<>();

        int lines = 0;

        BufferedReader reader;

        try {
            reader = new BufferedReader(new FileReader(path));

            String line = reader.readLine();

            if (avoidDoubles) {
                while (line != null) {
                    String[] splited = line.split("\t");

                    if (Integer.parseInt(splited[0]) < Integer.parseInt(splited[1])) {
                        vertices.add(splited[0]);
                        vertices.add(splited[1]);
                        edges.add(splited);
                    }

                    line = reader.readLine();
                    lines++;
                }

            } else {
                while (line != null) {
                    String[] splited = line.split("\t");

                    vertices.add(splited[0]);
                    vertices.add(splited[1]);
                    edges.add(splited);

                    line = reader.readLine();
                    lines++;
                }
            }

            System.out.println("Preparing done.");

            reader.close();
        } catch (IOException e) {
            e.printStackTrace();
        }

        System.out.println("Lines: " + lines);

        LinkedHashSet<String> hashSet = new LinkedHashSet<>(vertices);
        ArrayList<String> uniqueVertices = new ArrayList<>(hashSet);

        System.out.println("Unique vertices: " + uniqueVertices.size());

        for (Integer index : uniqueTests) {
            System.out.println("Unique " + index + ": " + uniqueVertices.get(index));
        }

        startTime = System.currentTimeMillis();

        for (String vertex : uniqueVertices) {
            graph.addVertex(vertex);
        }

        for (String[] edge : edges) {
            graph.addEdge(edge[0], edge[1]);
        }

        System.out.println("Loading done.");

        endTime = System.currentTimeMillis() - startTime;
        System.out.println("Loading time: " + endTime);

        System.out.println("Vertices: " + graph.vertexSet().size());
        System.out.println("Edges: " + graph.edgeSet().size());

        GraphIterator<String, DefaultEdge> iterator;
        List<String> visited;

        if (Arrays.stream(algorithms).anyMatch("bfs"::equals)) {
            startTime = System.currentTimeMillis();
            iterator = new BreadthFirstIterator<>(graph);

            visited = new ArrayList<>();
            iterator.forEachRemaining(visited::add);

            endTime = System.currentTimeMillis() - startTime;
            System.out.println("BFS time: " + endTime);
            System.out.println("BFS elements: " + visited.size());

            for (Integer index : indexes) {
                System.out.println(index + ": " + visited.get(index));
            }
        }

        if (Arrays.stream(algorithms).anyMatch("dfs"::equals)) {
            startTime = System.currentTimeMillis();
            iterator = new DepthFirstIterator<>(graph);

            visited = new ArrayList<>();
            iterator.forEachRemaining(visited::add);

            endTime = System.currentTimeMillis() - startTime;
            System.out.println("DFS time: " + endTime);
            System.out.println("DFS elements: " + visited.size());

            for (Integer index : indexes) {
                System.out.println(index + ": " + visited.get(index));
            }
        }

        if (Arrays.stream(algorithms).anyMatch("shortest"::equals)) {
            startTime = System.currentTimeMillis();
            DijkstraShortestPath shortest = new DijkstraShortestPath(graph);

            GraphPath shortestPath = shortest.getPath("0", "10000");

            endTime = System.currentTimeMillis() - startTime;
            System.out.println("Shortest time: " + endTime);
            System.out.println("Shortest elements: " + shortestPath.getEdgeList().size());
        }
    }
}