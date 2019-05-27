var core = require('./core');

const path = '../samples/test.txt';
const avoidDoubles = true;
const indexes = [0, 1, 2, 3, 4, 5, 6];

core.run(path, avoidDoubles, indexes);