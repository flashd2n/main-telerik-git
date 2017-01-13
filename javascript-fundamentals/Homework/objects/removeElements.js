'use strict';

function solve(args){
    let elementToRemove = args[0];
    let input = [];
    let argLen = args.length;
    

    for(let i = 1; i < argLen; i++){
        input.push(args[i]);
    }
    let inputLen = input.length;
    for(let i = 0; i < inputLen; i++){

        if(input[i] === elementToRemove){
            input.splice(i, 1);
            --i;
        }
    }
    for(let element of input){
        console.log(element);
    }

}

solve([ '_h/_,^54F#,V,^54F#,Z285,kv?tc`,^54F#,_h/_,Z285,_h/_,kv?tc`,Z285,^54F#,Z285,Z285,_h/_,^54F#,kv?tc`,kv?tc`,Z285' ]);