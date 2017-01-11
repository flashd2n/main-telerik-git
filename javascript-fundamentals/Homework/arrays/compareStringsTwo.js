'use strict';

function solve(args){
    let stringOne = String(args[0]),
        stringTwo = String(args[1]);
    
    if(stringOne.localeCompare(stringTwo) === 1){
        console.log('>');
    } else if(stringOne.localeCompare(stringTwo) === -1){
        console.log('<');
    } else{
        console.log('=');
    }
}
let arr = ['food', 'food'];
solve(arr);
