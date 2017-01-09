'use strict';

function solve(args){
    let number = Number(args[0]);

    if(number % 2 === 0){
        console.log(`even ${number}`);
    } else{
        console.log(`odd ${number}`);
    }
}