'use strict';

function solve(args){
    let numOne = Number(args[0]),
        numTwo = Number(args[1]),
        numThree = Number(args[2]),
        result;
    
    if(numOne > numTwo){
        if(numOne > numThree){
            result = numOne;
        } else{
            result = numThree;
        }
    } else{
        if(numTwo > numThree){
            result = numTwo;
        } else{
            result = numThree;
        }
    }
    console.log(result);
}