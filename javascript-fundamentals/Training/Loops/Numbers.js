'use strict';

function solve(args){
    let number = Number(args[0]),
        result = ``;

    for(let i  = 1; i <= number; i += 1){
        if(i === number){
            result += `${i}`;
        } else{
            result += `${i} `;
        }
    }
    console.log(result);
}