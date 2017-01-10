'use strict';

function solve(input) {
    let array = input,
        maxNumber = 0;

    for (let i = 0; i < array.length; i += 1) {
        if (maxNumber < +array[i]) {
          maxNumber = +array[i];
        }
    }
console.log(maxNumber);
}
solve(['5', '2', '1', '4', '2', '3']);