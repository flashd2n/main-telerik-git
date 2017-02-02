'use strict';

function f(y){
    return this.x + y;
}

let myObject = {
    x: 1
};

let newBinding = f.bind(myObject);

console.log(newBinding(2)); // this function is now bound to the object

console.log(f.call(myObject, 3)); // one time only

// you can play around with the binding functionality to pre-supply some parameters

let sum = function(x,y){return x + y;};
let newSum = sum.bind(null, 1); // now we have set the binding to null and the first arument (x) to 1, so when we call newSum we need to only supply y
console.log(newSum(4));

// we can take this one step further

function newFunc(y,z) {return this.x + y + z;}
let newFuncTwo = newFunc.bind({x: 1}, 4); // we pass the anon object with x property and y, so now the bound function need to only supply z argument;
console.log(newFuncTwo(5));
