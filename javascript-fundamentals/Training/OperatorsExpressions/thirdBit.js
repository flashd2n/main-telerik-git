'use strict';

function solve(args){
    let number = Number(args[0]);
    let bit = (number >> 3) & 1;
    console.log(bit);
}