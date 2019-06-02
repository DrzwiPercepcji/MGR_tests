import core

PATH = '../samples/test2.txt'
AVOID_DOUBLES = True
UNIQUE_TESTS = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
INDEXES = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
ALGORITHMS = ['bfs', 'dfs']

core.run(PATH, AVOID_DOUBLES, UNIQUE_TESTS, INDEXES, ALGORITHMS)