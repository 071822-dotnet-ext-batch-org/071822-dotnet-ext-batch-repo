"use strict";

console.log('Hey there Tiger!');
console.log("Hey there Tiger!");

// alert('Your browser is hacked!');
// confirm("do you want to continue!?");
// let ret = prompt('This is a prompt', 'Yes');

// console.log(`You answered ${ret}`);

//using {} here is very similar to the C# using();
{
  let var1 = 5;//when a variable is declared with let, it has block scope and cannot be used outside the scope it was declared inside.
  var var2 = 6;// whereas, a variale declared with var (the older one), it CAN be used outside that scope.
}
//console.log(var1);// cannot be used because line 12 declared this variale with 'let'
console.log(var2);// can be used because this variable was declared with 'var'

//JS does not have int, bool, double, string, etc as declaring keywords.
//js has WEAK TYPING
var2 = 'JIMMY CRACKED CORN AND I don\'t care!'
console.log(`I wrote...${var2}`)
//'var' in C# gives the runtime the prerogative to assign the datatype.
// After declaration, a C# variable cannot be changed, except under certain conditions.

let mystring = 'this is a string';
console.log(mystring);
mystring = 1034;
console.log(mystring);

// 'const' is the JS version of 'readonly' in C#
const MYCONST = 'Who ya gonna call?...'
console.log(MYCONST);
const MYCONST1 = MYCONST + '\n\n\tGhostbusters!';
console.log(MYCONST1);

let five = 5, four = 4;
console.log(five - four);
console.log(five + four);
console.log(five ** four);
console.log(Math.pow(five, four));

console.log(five % four);
let res = five / four;
console.log(res);
console.log(five / four);
console.log(five * four);

five = '5';
console.log(five == 5);// TRUE
five = 5;
console.log(five === 5);// FALSE

//truthy and false. Accoring to Ian, if you are evaluating a 'nothingburger' you get false.
// falsey = false, "", 0, NaN, null, undefined.
// EVERYTHING ELSE IS TRUTHY!!!
if (null) {
  console.log("WHAT?!? an empty string is TRUE?");
}
else {
  console.log("As expected an empty string evaluates to false.");
}

let five1 = String(five);
console.log(five1);

let five2 = Number(five1);
console.log(five2);

let five3 = Boolean(five1);// '5'
console.log(five3);

let five4 = Boolean(('0'));// '0'
console.log(five4);

// JSON in JavaScript
// create a JS object
let jason = {
  name: "Mark Moore",
  age: 43,
  height: "6'1\""
};
let jasonStr = JSON.stringify(jason);// create a JSON string out of that object
console.log(jasonStr);
let jasonStr1 = JSON.parse(jasonStr);// convert that string back into the original object
console.log(jasonStr1);
console.log(jasonStr1.name, jasonStr1.age, jasonStr1.height);

jason.weight = 345;
console.log(jason);

function func1(param1, param2) {
  console.log(`Theres a ${param1} function ${param2}ing here!`);
}
func1();//invoke the function with '()'
func1('dang', "funct");

let func2 = func1;
func2();
console.log(func2());

function func3(param1, param2) {
  return `Theres a ${param1} function ${param2}ing here!`;
}
console.log(func3('short', 'rollerblad'));

//function expression
let func4 = function (param1) {
  return ++param1;
}
let five5 = 10
console.log(func4(five5));
console.log(five5);

// arrow functions
let func7 = () => "congrats. you called a 0 parameter function";//arrow func with 0 params
let func5 = param1 => ++param1;//arrow func with 1 params
let func6 = (p1, p2) => ++p1 + p2;//arrow func with 2 params
let ret5 = func5(5);
console.log(ret5);

let func8 = p1 => {
  let myVar = `${p1} is `;
  let myvar1 = 'Spartaaaaa!'
  return myVar + myvar1;
}

console.log(func8('Curly\'s Plumbing'));

let func9 = (p1, p2) => {
  let res = p1(p2);
  let myVar = `${res} is `;
  let myvar1 = 'Spartaaaaa!'
  return myVar + myvar1;
}

let myp1 = (p1) => {
  let swords = p1;
  swords += swords;
  return swords;
}
// this is myp1 used as a callback function
let res1 = func9(myp1, 'magnis');// send a function WITHOUT the ().
console.log(res1);


// IIFE ("Iffy") do not have parameters because they  are immediately envoked
// as soon as the compiler reaches them. they are not called by any other part of the code/
(() => {
  console.log("Hey there tiger!?");
  console.log("Want some juicy gazelle meat!");
})();

// CLOSURE of a nested function!!!
function MyNested(p1) {// this function is declared with 1 param.
  // let p11 = p1
  return () => ++p1;// it returns a function (that returns the incremented param)
}

let mynested1 = MyNested(40);
console.log(mynested1);
console.log(`mynested returned ${mynested1()}`);
console.log(`mynested returned ${mynested1()}`);
console.log(`mynested returned ${mynested1()}`);
console.log(`mynested returned ${mynested1()}`);
console.log(`mynested returned ${mynested1()}`);

let m1 = {
  name1: 'Mark',
  age: 43,
}
// you can add a function after the creation of the object.
// arrow function doesn't work... for some reason
m1.myDeets = function () {
  return `${this.name1} is ${this.age} years oooold.`
}
console.log(m1.myDeets());//then call it

let m3 = class m2 {
  constructor(name, age) {
    this.name1 = name;
    this.age = age;
  }
};
let m4 = new m3('Jim', 18);
console.log(m4.age, m4.name1, m3.name);
let m5 = new m3('Arely', 40);
console.log(m5.age, m5.name1);

class m6 {
  constructor(name = 'Mac', age = 11) {
    this.name1 = name;
    this.age = age;
    this.incTheCounter();
  }

  incTheCounter = function () {
    this.count += this.count;
  }

  get nameAndAge() {
    return `${this.name1} is ${this.age} years oooold.`
  }

  set setage(v) {
    if (v > 100 || v < 1) throw new RangeError(`That age, ${v} is invalid`);
    else this.age = v;
  }
  //section below is all static members.
  static count = 0;
  static staticName = 'Mac';//create a static property
  static gimmeStatic() {// static functions can only access static properties.
    ++this.count;
    return `Do you wanna get jammed up ${this.count} times, ${this.staticName}?`
  }
};

let m7 = new m6('Mominur', 30);
console.log(m7.nameAndAge);
m7.setage = 25;
console.log(m7.nameAndAge);
// m7.setage = 125;// set a valid that will throw the error.
console.log(m6.gimmeStatic());

let m8 = new m6();
console.log(m8.name1, m8.age);

let m9 = new m6('Dave');
console.log(m9.name1, m9.age);

class m6Inheriting extends m6 {
  constructor(myName, page, address = '112 Main Blvd.') {
    super(myName, page);
    this.address = address;
  };
};

let n1 = new m6Inheriting('Larry', 37);
console.log(`My best friend ${n1.name1} is ${n1.age} years young and lives at ${n1.address}`);
// console.log(`The ${m6.gimmeStatic()}`);
// console.log(`The ${m6.gimmeStatic()}`);
// console.log(`The ${m6.gimmeStatic()}`);
// console.log(`The ${m6.gimmeStatic()}`);
// console.log(`The ${m6.gimmeStatic()}`);
console.log(`The counteris => ${m6.count}`);

// I think this connection to the html is dynamic... so when we add <p> elements to the html
// the HtmlCollection gets bigger... so we end up in an infinite loop.
let paras = document.getElementsByTagName('p');

//copy all elements to a new array
let myArray = [];
for (let i = 0; i < paras.length; i++) {
  myArray.push(paras[i]);
}
let bodie = document.body;
let mydiv = document.createElement("div");
bodie.appendChild(mydiv);
let counter = 0;
let myelem = 'div'
for (let p1 of myArray) {
  counter++;
  mydiv.innerHTML += `<${myelem}>${counter} - ${p1.textContent}</${myelem}}>`;
}

// for (let p1 of myArray) {
//   counter++;
//   let newP = document.createElement('p');
//   newP.innerText = `${counter} - ${p1.innerText}`;
//   mydiv.appendChild(newP);
// }

const list = document.querySelector('.oli');
console.log(list.lastElementChild.textContent);
// list.lastElementChild.classList.add("redBackground");
let button = document.querySelector("button");
button.addEventListener('click', (e) => {
  e.stopPropagation();
  // dynamically apply and remove the classList
  let elem = list.lastElementChild;
  if (elem.classList.contains("redBackground")) {
    elem.classList.remove('redBackground');
  }
  else {
    list.lastElementChild.classList.add("redBackground");
  }
});

function HeBitMe() {
  console.log('Charlie, bit me!!!');
}










console.log();
