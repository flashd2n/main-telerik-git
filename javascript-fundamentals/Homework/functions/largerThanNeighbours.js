'use strict';

function solve(args) {
    let len = +args[0];
    let arr = args[1].split(' ').map(Number);
    let result = +CountLargerThanNeighbours(arr, len);
    console.log(result);

    function CountLargerThanNeighbours(array, length) {
        let count = 0;

        for(let i = 0; i < len; i ++) {
             if(i !== 0 && i < len - 1 && array[i] > array[i + 1] && array[i] > array[i - 1]) {
                 ++count ;
             }
        }
        return count;
    }
}

solve('6,-26 -25 -28 31 2 27');