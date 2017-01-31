'use strict';

let operators = {
    add: (x, y) => x + y,
    subtract: (x, y) => x - y,
    multiply: (x , y) => x * y,
    divide: (x, y) => x / y 
};

function operate(operation, operandOne, operandTwo){
    if(typeof operators[operation] === `function`){
        return operators[operation](operandOne, operandTwo);
    } else {
        throw new Error(`The supplied operation is not valid`);
    }
}

console.log(operate(`subtract`, 4, 5));

// function parameters

myFunction.uniqueID = 0;

function myFunction(){
    return myFunction.uniqueID++;
}

console.log(myFunction());
console.log(myFunction());
console.log(myFunction());