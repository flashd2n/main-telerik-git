'use strict';

function solve(args){
    let arraySize = +args[0];

    for(let i = 0; i < arraySize; i++){
        console.log(i * 5);
    }
}

let arr = ['10'];
solve(arr);