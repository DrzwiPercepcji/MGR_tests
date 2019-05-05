from igraph import *
import time

PATH = '../samples/roadNet-PA.txt'
AVOID_DOUBLES = True
INDEXES = [100, 1000, 10000, 100000]

g = Graph()

with open(PATH) as fp:

    vertices = []
    edges = []

    print('Preparing...')

    line = fp.readline()

    if AVOID_DOUBLES:
        while line:
            splited = line.split('\t')

            splited[0] = str(int(splited[0]))
            splited[1] = str(int(splited[1]))

            if splited[0] < splited[1]:
                vertices.append(splited[0])
                vertices.append(splited[1])
                edges.append(splited)

            line = fp.readline()
    else:
        while line:
            splited = line.split('\t')

            splited[0] = str(int(splited[0]))
            splited[1] = str(int(splited[1]))

            vertices.append(splited[0])
            vertices.append(splited[1])
            edges.append(splited)

            line = fp.readline()

    uniqueVertices = list(set(vertices))

    print('Unique vertices: ' + str(len(uniqueVertices)))

    print('Preparing done.')

start_time = time.time()

for vertex in uniqueVertices:
    g.add_vertex(vertex)

g.add_edges(edges)

print('Loading done.')

print("Loading time: %s seconds" % (time.time() - start_time))

print('Vertices: ' + str(len(g.vs)))
print('Edges: ' + str(len(g.es)))

start_time = time.time()

path = g.bfs(0)[0]

print('BFS done.')

print("BFS time: %s seconds" % (time.time() - start_time))
print('BFS elements: ' + str(len(path)))

for index in INDEXES:
    print(str(index) + ': ' + str(path[index]))