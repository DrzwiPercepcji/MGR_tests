var core = require('./core');

const path = '../samples/Email-Enron.txt';
const avoidDoubles = true;
const uniqueTests = [100, 1000, 10000];
const indexes = [100, 1000, 10000];

core.run(path, avoidDoubles, uniqueTests, indexes);