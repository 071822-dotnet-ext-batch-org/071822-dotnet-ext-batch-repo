console.log('Hey Hey world! We\'re the ...');

/*each file constitutes a 'module'. a module
(or the parts that you want available in the global scope)
 must be exported from the file where they are declared
 an imported into the file where they will be used.
*/
let myVar = 'Mark';
function myFunc(str, myInt) {
  return `${str} are ${myInt} times more likely to drop out of school.`
}

// module.exports = myVar;
exports.myVar = myVar;
exports.myFunc = myFunc;



