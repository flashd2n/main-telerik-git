'use strict';

let objectOne = {
    x: 1
};

// query property meta data

console.log(Object.getOwnPropertyDescriptor(objectOne, `x`));

if(Object.getOwnPropertyDescriptor(objectOne, `x`).enumerable === true){
    console.log(`The property is enumerable`);
} else{
    console.log(`The property is not enumerable`);
}

// configure property meta data

Object.defineProperty(objectOne, `y`, {value: 5, writable: true, enumerable: false, configurable: true}); // set as a data property

console.log(Object.keys(objectOne));

if(Object.getOwnPropertyDescriptor(objectOne, `y`).enumerable === true){
    console.log(`The property is enumerable`);
} else{
    console.log(`The property is not enumerable`);
}

Object.defineProperty(objectOne, `y`, {writable: false});

Object.defineProperty(objectOne, `y`, {get: function(){ return 0;}}); // convert data property to accessor property

console.log(objectOne.y);

// configure multiple properties simultaneously

let objectTwo = Object.defineProperties({}, {
    x: {value: 50, writable: true, enumerable: true, configurable: true},
    y: {value: 60, writable: false, enumerable: false, configurable: true},
    z: {get: function(){ return Math.sqrt(this.x * this.x + this.y * this.y);}, enumerable: true, configurable: true }
});

console.log(objectTwo);
console.log(objectTwo.z);


// gets all property names of an object -> even the nonenumerable ones

console.log(Object.getOwnPropertyNames(objectTwo));