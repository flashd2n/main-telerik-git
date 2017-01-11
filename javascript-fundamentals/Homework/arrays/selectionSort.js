'use strict';

function solve(args){

    let tempMin = Number.MAX_SAFE_INTEGER,
        minIndex = 0,
        tempSwitch = 0;

    for(let i = 0, len = args.length; i < len; i++){

        for(let j = i; j < len; j++){

            if(+args[j] < tempMin){
                tempMin = +args[j];
                minIndex = j;
            }
        }
        tempSwitch = +args[i];
        args[i] = +args[minIndex];
        args[minIndex] = tempSwitch;
        tempMin = Number.MAX_SAFE_INTEGER;
    }
    //remove dublicates
    for(let i = 0, len = args.length; i < len - 1; i++){
        if(+args[i] === +args[i + 1]) {
            args.splice(i + 1, 1);
        }
    }
    //print
    for(let i = 0, len = args.length; i < len; i++){
        console.log(+args[i]);
    }
}

let arr = ['6', '3', '4', '1', '5', '2', '6'];
solve(arr);