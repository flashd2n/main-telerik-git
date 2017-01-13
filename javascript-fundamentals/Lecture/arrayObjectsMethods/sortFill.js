'use strict';

let array = [1, 42,53, 32, -1, -31, 23, 43, 56, 76];

// console.log(array);
// array.sort(); // sorts lexicographically (tostings everything)
// console.log(array);

console.log(array);
array.sort((x, y) => x - y); // ascending as numbers
console.log(array);

console.log(array.fill(12, 1, 3)); // modifies the current array
console.log(array);