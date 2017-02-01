'use strict';

let scope = `global`;

function checkScope(){
    let scope = `local`;
    function f(){return scope;}
    return f();
}

console.log(checkScope());

function checkScopeTwo(){
    let scope = `local`;
    function f(){return scope;}
    return f;
}

console.log(checkScopeTwo()()); // function lexical scope is in effect when defining the fuction not when invoking, that's why this returns local


let uniqueID = (function(){
    let counter = 0;
    return function(){return ++counter;};
})();

console.log(uniqueID());
console.log(uniqueID());
console.log(uniqueID());

console.log(`class-like stuff`);

function counter(){
    let count = 0;
    return{
        increment: () => ++count,
        reset: () => count = 0
    };
}

let firstCounter = counter();

console.log(firstCounter.increment());
console.log(firstCounter.increment());

let secondCounter = counter();

console.log(secondCounter.increment());

// firstCounter and secondCounter are two different instances of the function counter === something like counter is a class and first and secondCounter are objects of that class
