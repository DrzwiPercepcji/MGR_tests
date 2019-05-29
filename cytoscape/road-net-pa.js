var core = require('./core');

const path = '../samples/roadNet-PA.txt';
const avoidDoubles = true;
const uniqueTests = [100, 1000, 10000, 100000];
const indexes = [100, 1000, 10000, 100000];
const algorithms = ['bfs', 'dfs', 'shortest'];

core.run(path, avoidDoubles, uniqueTests, indexes, algorithms);