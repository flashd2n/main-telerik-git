'use strict';

function solve(args){
    let maxNumber = Number(args[0]),
    arrayCheck = [];
    // arrayCheck = Array(maxNumber).fill(true);
    for(let i = 2; i <= maxNumber; i++ ){
        arrayCheck[i] = true;
    }

    for(let i = 2; i <= Math.sqrt(maxNumber); i++){

        if(arrayCheck[i] === true){
            for(let j = i * i; j <= maxNumber; j += i){
                arrayCheck[j] = false;
            }
        }
    }

    let result = arrayCheck.lastIndexOf(true);
    console.log(result);
}

let arr = ['10'];
solve(arr);