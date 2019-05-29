from igraph import *
import time

graph = Graph()

def run(path, avoidDoubles, uniqueTests, indexes, algorithms):

    with open(path) as fp:

        vertices = []
        edges = []

        print('Preparing...')

        lines = 0
        line = fp.readline()

        if avoidDoubles:
            while line:
                splited = line.split('\t')

                splited[0] = str(int(splited[0]))
                splited[1] = str(int(splited[1]))

                if splited[0] < splited[1]:
                    vertices.append(splited[0])
                    vertices.append(splited[1])
                    edges.append(splited)

                line = fp.readline()
                lines += 1
        else:
            while line:
                splited = line.split('\t')

                splited[0] = str(int(splited[0]))
                splited[1] = str(int(splited[1]))

                vertices.append(splited[0])
                vertices.append(splited[1])
                edges.append(splited)

                line = fp.readline()
                lines += 1
        
        print('Lines: ' + str(lines))

        uniqueVertices = list(dict.fromkeys(vertices))

        print('Unique vertices: ' + str(len(uniqueVertices)))

        for index in uniqueTests:
            print('Unique ' + str(index) + ': ' + str(uniqueVertices[index]))

        print('Preparing done.')

    start_time = time.time()

    for vertex in uniqueVertices:
        graph.add_vertex(vertex)

    graph.add_edges(edges)

    print('Loading done.')

    print("Loading time: %s seconds" % (time.time() - start_time))

    print('Vertices: ' + str(len(graph.vs)))
    print('Edges: ' + str(len(graph.es)))

    if 'bfs' in algorithms:
        start_time = time.time()

        path = graph.bfs(0)[0]

        print('BFS done.')

        print("BFS time: %s seconds" % (time.time() - start_time))
        print('BFS elements: ' + str(len(path)))

        for index in indexes:
            print(str(index) + ': ' + str(path[index]))
    
    if 'shortest' in algorithms:
        start_time = time.time()

        path = graph.shortest_paths_dijkstra(0, 10000)

        print('Shortest done.')

        print("Shortest time: %s seconds" % (time.time() - start_time))
        print('Shortest elements: ' + str(path))