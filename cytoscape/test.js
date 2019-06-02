var core = require('./core');

const path = '../samples/test2.txt';
const avoidDoubles = true;
const uniqueTests = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
const indexes = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
const algorithms = ['bfs', 'dfs'];

core.run(path, avoidDoubles, uniqueTests, indexes, algorithms);