'use strict';

let array = [1, 42,53, 32, -1, -31, 23, 43, 56, 76];

console.log(array.find(x => x < 0)); // returns the first element who is true for the condition

console.log(array.findIndex(x => x < 0)); // does the above, but returns the index of the found element

