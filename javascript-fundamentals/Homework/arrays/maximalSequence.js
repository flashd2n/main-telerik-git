'use strict';

function solve(args){
    let maxSequence = 1,
        tempSequence = 1;

    for(let i = 0, len = args.length; i < len - 1; i++){

        if(+args[i] === +args[i + 1]){
            ++tempSequence;
            if(tempSequence > maxSequence){
            maxSequence = tempSequence;
        }
        } else{
            tempSequence = 1;
        }

    }
    console.log(maxSequence);
}

let arr = ['10', '10', '10', '10', '10', '10', '10', '10', '10', '10', '10'];
solve(arr);