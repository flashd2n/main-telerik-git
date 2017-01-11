'use strict';

function solve(args){
    let number = Number(args[0]),
        result = ``;

    for(let i  = 1; i <= number; i += 1){
        
            result += `${i} `;
    }
    console.log(result);
}

let arr = ['1'];
solve(arr);