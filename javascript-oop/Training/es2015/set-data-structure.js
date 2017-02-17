'use strict';

// Set will not add a pre-existing element to the collection. Set contains only keys, no values

const mySet = new Set();

mySet.add(`pesho`);
mySet.add(`stamat`);
mySet.add(`pesho`);
mySet.add(`pesho`);

console.log(mySet);

for(let element of mySet){
    console.log(element);
}