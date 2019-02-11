import java.awt.Dimension;
import javax.swing.JFrame;

import edu.uci.ics.jung.graph.*;
import edu.uci.ics.jung.visualization.*;
import edu.uci.ics.jung.algorithms.layout.*;

public class Example {
    public static void main(String[] args) {
        //DirectedSparseGraph g = new DirectedSparseGraph();
        UndirectedSparseGraph g = new UndirectedSparseGraph();

        g.addVertex("Vertex1");
        g.addVertex("Vertex2");
        g.addVertex("Vertex3");
        g.addEdge("Edge1", "Vertex1", "Vertex2");
        g.addEdge("Edge2", "Vertex1", "Vertex3");
        g.addEdge("Edge3", "Vertex3", "Vertex1");

        System.out.println("The graph g = " + g.toString());

        VisualizationImageServer vs =
                new VisualizationImageServer(
                        new CircleLayout(g), new Dimension(200, 200));

        JFrame frame = new JFrame();
        frame.getContentPane().add(vs);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.pack();
        frame.setVisible(true);
    }
}
