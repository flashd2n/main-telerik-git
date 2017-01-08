'use strict';

function solve(args){
    let highest = Number.MIN_SAFE_INTEGER;
    
    for(let i = 0; i < args.length; i += 1){
        
        if(+args[i] > highest){
            highest = +args[i];
        }   
    }
    console.log(highest);    
}