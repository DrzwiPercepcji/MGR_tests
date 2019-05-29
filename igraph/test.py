import core

PATH = '../samples/test.txt'
AVOID_DOUBLES = True
UNIQUE_TESTS = [0, 1, 2, 3, 4, 5, 6]
INDEXES = [0, 1, 2, 3, 4, 5, 6]
ALGORITHMS = ['bfs', 'dfs']

core.run(PATH, AVOID_DOUBLES, UNIQUE_TESTS, INDEXES, ALGORITHMS)