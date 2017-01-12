'use strict';

function solve(args){
    let array = [];
    let tempMin = Number.MAX_SAFE_INTEGER,
        minIndex = 0,
        tempSwitch = 0;

    for(let i = 1, len = args.length; i < len; i++){
        array.push(+args[i]);
    }
    
    for(let i = 0, len = array.length; i < len; i++){

        for(let j = i; j < len; j++){

            if(array[j] < tempMin){
                tempMin = array[j];
                minIndex = j;
            }
        }
        tempSwitch = array[i];
        array[i] = array[minIndex];
        array[minIndex] = tempSwitch;
        tempMin = Number.MAX_SAFE_INTEGER;
    }
    //print
    for(let i = 0, len = array.length; i < len; i++){
        console.log(array[i]);
    }
}

let arr = ['6', '3', '4', '1', '5', '2', '6'];
solve(arr);