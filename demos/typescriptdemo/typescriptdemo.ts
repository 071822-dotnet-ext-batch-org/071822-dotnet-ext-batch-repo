import { MyClass } from './otherfile';


console.log('Hello, World');
let myClass1 = new MyClass('Richard the LionHeart is coming',
  (a: string) => {
    return `This ${a} is better than our kingdoms.`
  });

console.log(myClass1.name, myClass1.sound('pair of warthogs'));

