'use strict';

// same as Set, but can add value to the key

let myMap = new Map();

myMap.set(`pesho`, 4); // creates and sets pesho key + value
myMap.set(`stamat`, 5); // creates and sets stamat key + value
myMap.set(`pesho`, 6); // updates pesho value
myMap.set(`pesho`, 7); // updates pesho value

console.log(myMap);
console.log(`======`);
console.log(myMap.values());
console.log(myMap.keys());

console.log(`====iterating the collection=====`);
for(let [key, value] of myMap){
    console.log(key);
    console.log(value);
}

console.log(`====iterating values=====`);
for(let value of myMap.values()){
    console.log(value);
}

console.log(`====iterating keys=====`);
for(let key of myMap.keys()){
    console.log(key);
}

console.log(myMap.entries()); // pretty much useless
console.log(`======`);
console.log(myMap.get('pesho')); // returns the value of that key
console.log(myMap.has('peshoo')); // returns bool whether this key has value / has been assigned
console.log(myMap.size); // gets the length of the collection
console.log(`====iterating with forEach=====`);

myMap.forEach(function(value, key) { // usefull iteration
  console.log(`${key} = ${value}`);
});