'use strict';

// requesting object as a parameter in order to make it easy for invoking

function easyArrayCopy(args){
    let startArray = args.from || [],
    indexStart = args.fromStart || 0,
    recipientArray = args.to || [],
    recipientStart = args.toStart || 0,
    length = args.length || startArray.length;
    
    arrayCopy(startArray, indexStart, recipientArray, recipientStart, length);

    function arrayCopy(startArray, indexStart, recipientArray, recipientStart, length){
        //some code that does stuff and return the result array
    }
}

let arrayA = [1,2,3,4,5];
let arrayB = [];

let resultArray = easyArrayCopy({from: arrayA, to: arrayB, length: 3});
