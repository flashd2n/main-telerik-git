'use strict';

function solve(args){
    let array = [];

    for(let i = 1, len = args.length; i < len; i++){
        array.push(+args[i]);
    }

    array.sort();

    let tempOccurences = 1,
        maxOccurences = 1,
        frequentNumber = 0;

    for(let i = 0, len = array.length - 1; i < len; i++){

        if(array[i] === array[i + 1]){
            ++tempOccurences;
        } else{
            tempOccurences = 1;
        }
        if(tempOccurences > maxOccurences){
            maxOccurences = tempOccurences;
            frequentNumber = array[i];
        }
    }
    console.log(`${frequentNumber} (${maxOccurences} times)`);
}

let arr = ['13', '4', '1', '1', '4', '2', '3', '4', '4', '1', '2', '4', '9', '3'];
solve(arr);