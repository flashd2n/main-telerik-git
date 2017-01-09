'use strict';

function solve(args){
    let number = Number(args[0]);
    let thirdDigit = Math.trunc((number / 100) % 10);

    if(thirdDigit === 7){
        console.log(`true`);
    } else {
        console.log(`false ${thirdDigit}`);
    }
}