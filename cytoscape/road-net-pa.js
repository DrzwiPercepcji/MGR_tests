var core = require('./core');

const path = '../samples/roadNet-PA.txt';
const avoidDoubles = true;
const indexes = [100, 1000, 10000, 100000];

core.run(path, avoidDoubles, indexes);