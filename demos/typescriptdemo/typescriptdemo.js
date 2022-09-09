import { MyClass } from './otherfile.js';// THe typescript doesn;t let you use the suffix, but we had to add the suffix here in the .js file.
console.log('Hello, World');
let myClass1 = new MyClass('Richard the LionHeart is coming', (a) => {
    return `This ${a} is better than our kingdoms.`;
});
console.log(myClass1.name, myClass1.sound('pair of warthogs'));
