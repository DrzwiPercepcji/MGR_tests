import core

PATH = '../samples/roadNet-PA.txt'
AVOID_DOUBLES = True
UNIQUE_TESTS = [100, 1000, 10000, 100000]
INDEXES = [100, 1000, 10000, 100000]
ALGORITHMS = ['bfs', 'dfs', 'shortest']

core.run(PATH, AVOID_DOUBLES, UNIQUE_TESTS, INDEXES, ALGORITHMS)