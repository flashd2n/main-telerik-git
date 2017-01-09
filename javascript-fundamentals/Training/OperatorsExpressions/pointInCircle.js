'use strict';

function solve(args){
    let x = Number(args[0]),
        y = Number(args[1]);
    
    if(x * x + y * y <= 4){
        console.log(`yes ${Math.sqrt(x * x + y * y).toFixed(2)}`);
    } else{
        console.log(`no ${Math.sqrt(x * x + y * y).toFixed(2)}`);
    }
}