var core = require('./core');

const path = '../samples/Email-Enron.txt';
const avoidDoubles = true;
const indexes = [100, 1000, 10000];

core.run(path, avoidDoubles, indexes);