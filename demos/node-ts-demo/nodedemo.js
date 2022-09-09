const otherFile = require('./otherFile.js');
const fs = require('fs-extra');

console.log(`${otherFile.myVar} is one of the Monkeys`);

console.log(otherFile.myFunc('People who are not at 4th grade reading level by 10 years old,', 5));

fs.writeFileSync('./DeepThoughts.txt', 'Sometimes I wonder if penguins have Napoleon complex.');


/**
 * Create some functions that will:
 * 1. write to a new file, 
 * 2. append to that new file, 
 * 3. read from that file and 
 * 4. print the contents to the console 
 * 5. use variable(s) and a function that you exported from another module(file).
 * ...using Node, ect
 */