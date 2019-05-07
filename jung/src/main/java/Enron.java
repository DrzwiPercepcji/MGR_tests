import edu.uci.ics.jung.algorithms.shortestpath.BFSDistanceLabeler;
import edu.uci.ics.jung.graph.*;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.LinkedHashSet;
import java.util.List;

public class Enron {

    private static final String PATH = "../samples/Email-Enron.txt";
    private static final Boolean AVOID_DOUBLES = true;
    private static final Integer[] INDEXES = {100, 1000, 10000};

    public static void main(String[] args) {

        long startTime;
        long endTime;

        UndirectedSparseGraph graph = new UndirectedSparseGraph();

        System.out.println("Preparing...");

        ArrayList<String> vertices = new ArrayList<>();
        ArrayList<String[]> edges = new ArrayList<>();

        BufferedReader reader;

        try {
            reader = new BufferedReader(new FileReader(PATH));

            String line = reader.readLine();

            if (AVOID_DOUBLES) {
                while (line != null) {
                    String[] splited = line.split("\t");

                    if (Integer.parseInt(splited[0]) < Integer.parseInt(splited[1])) {
                        vertices.add(splited[0]);
                        vertices.add(splited[1]);
                        edges.add(splited);
                    }

                    line = reader.readLine();
                }

            } else {
                while (line != null) {
                    String[] splited = line.split("\t");

                    vertices.add(splited[0]);
                    vertices.add(splited[1]);
                    edges.add(splited);

                    line = reader.readLine();
                }
            }

            System.out.println("Preparing done.");

            reader.close();
        } catch (IOException e) {
            e.printStackTrace();
        }

        LinkedHashSet<String> hashSet = new LinkedHashSet<>(vertices);
        ArrayList<String> uniqueVertices = new ArrayList<>(hashSet);

        System.out.println("Unique vertices: " + uniqueVertices.size());

        startTime = System.currentTimeMillis();

        for (String vertex : uniqueVertices) {
            graph.addVertex(vertex);
        }

        int edgeIndex = 0;
        for (String[] edge : edges) {
            graph.addEdge("Edge" + edgeIndex, edge[0], edge[1]);
            edgeIndex++;
        }

        System.out.println("Loading done.");

        endTime = System.currentTimeMillis() - startTime;
        System.out.println("Loading time: " + endTime);

        System.out.println("Vertices: " + graph.getVertexCount());
        System.out.println("Edges: " + graph.getEdgeCount());

        startTime = System.currentTimeMillis();
        BFSDistanceLabeler bfs = new BFSDistanceLabeler();
        bfs.labelDistances(graph, "0");

        List<String> path = bfs.getVerticesInOrderVisited();

        endTime = System.currentTimeMillis() - startTime;
        System.out.println("BFS time: " + endTime);
        System.out.println("BFS elements: " + path.size());

        for (Integer index : INDEXES) {
            System.out.println(index + ": " + path.get(index));
        }
    }
}