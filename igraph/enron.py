import core

PATH = '../samples/Email-Enron.txt'
AVOID_DOUBLES = True
UNIQUE_TESTS = [100, 1000, 10000]
INDEXES = [100, 1000, 10000]
ALGORITHMS = ['bfs', 'dfs', 'shortest']

core.run(PATH, AVOID_DOUBLES, UNIQUE_TESTS, INDEXES, ALGORITHMS)