import org.jgrapht.*;
import org.jgrapht.graph.*;
import org.jgrapht.io.*;
import org.jgrapht.traverse.*;

import java.io.*;
import java.net.*;
import java.util.*;

public final class Example {
    public static void main(String[] args)
            throws URISyntaxException,
            ExportException {
        Graph<String, DefaultEdge> stringGraph = createStringGraph();

        System.out.println("-- toString output");
        System.out.println(stringGraph.toString());
        System.out.println();

        Graph<URI, DefaultEdge> hrefGraph = createHrefGraph();

        URI start = hrefGraph
                .vertexSet().stream().filter(uri -> uri.getHost().equals("www.jgrapht.org")).findAny()
                .get();

        System.out.println("-- traverseHrefGraph output");
        traverseHrefGraph(hrefGraph, start);
        System.out.println();

        System.out.println("-- renderHrefGraph output");
        renderHrefGraph(hrefGraph);
        System.out.println();
    }

    private static Graph<URI, DefaultEdge> createHrefGraph()
            throws URISyntaxException {

        Graph<URI, DefaultEdge> g = new DefaultDirectedGraph<>(DefaultEdge.class);

        URI google = new URI("http://www.google.com");
        URI wikipedia = new URI("http://www.wikipedia.org");
        URI jgrapht = new URI("http://www.jgrapht.org");

        g.addVertex(google);
        g.addVertex(wikipedia);
        g.addVertex(jgrapht);

        g.addEdge(jgrapht, wikipedia);
        g.addEdge(google, jgrapht);
        g.addEdge(google, wikipedia);
        g.addEdge(wikipedia, google);

        return g;
    }

    private static void traverseHrefGraph(Graph<URI, DefaultEdge> hrefGraph, URI start) {
        Iterator<URI> iterator = new DepthFirstIterator<>(hrefGraph, start);
        while (iterator.hasNext()) {
            URI uri = iterator.next();
            System.out.println(uri);
        }
    }

    private static void renderHrefGraph(Graph<URI, DefaultEdge> hrefGraph)
            throws ExportException {
        ComponentNameProvider<URI> vertexIdProvider = new ComponentNameProvider<URI>() {
            public String getName(URI uri) {
                return uri.getHost().replace('.', '_');
            }
        };
        ComponentNameProvider<URI> vertexLabelProvider = new ComponentNameProvider<URI>() {
            public String getName(URI uri) {
                return uri.toString();
            }
        };
        GraphExporter<URI, DefaultEdge> exporter =
                new DOTExporter<>(vertexIdProvider, vertexLabelProvider, null);
        Writer writer = new StringWriter();
        exporter.exportGraph(hrefGraph, writer);
        System.out.println(writer.toString());
    }

    private static Graph<String, DefaultEdge> createStringGraph() {
        Graph<String, DefaultEdge> g = new SimpleGraph<>(DefaultEdge.class);

        String v1 = "v1";
        String v2 = "v2";
        String v3 = "v3";
        String v4 = "v4";

        g.addVertex(v1);
        g.addVertex(v2);
        g.addVertex(v3);
        g.addVertex(v4);

        g.addEdge(v1, v2);
        g.addEdge(v2, v3);
        g.addEdge(v3, v4);
        g.addEdge(v4, v1);

        return g;
    }
}
