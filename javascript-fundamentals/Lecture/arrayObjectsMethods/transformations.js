'use strict';

let array = [1, 42,53, 32, -1, -31, 23, 43, 56, 76];

console.log(array.filter(x => x % 2 === 0)); // returns new array
console.log(array);

console.log(array.map(x => x * 2)); // returns new array
console.log(array);

