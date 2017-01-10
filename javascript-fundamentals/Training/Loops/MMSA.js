'use strict';

function solve(args){
    let minimal = Number.MAX_SAFE_INTEGER,
        maximal = Number.MIN_SAFE_INTEGER,
        sum = 0,
        average = 1;

    for(let i  = 0; i < args.length; i++ ){
        if(args[i] < minimal){
            minimal = +args[i];
        }
        if(args[i] > maximal){
            maximal = +args[i];
        }
        sum += +args[i];

    }
    average = sum / args.length;

    console.log(`min=${minimal.toFixed(2)}`);
    console.log(`max=${maximal.toFixed(2)}`);
    console.log(`sum=${sum.toFixed(2)}`);
    console.log(`avg=${average.toFixed(2)}`);
}