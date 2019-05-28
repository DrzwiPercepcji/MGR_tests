var core = require('./core');

const path = '../samples/test.txt';
const avoidDoubles = true;
const uniqueTests = [0, 1, 2, 3, 4, 5, 6];
const indexes = [0, 1, 2, 3, 4, 5, 6];

core.run(path, avoidDoubles, uniqueTests, indexes);