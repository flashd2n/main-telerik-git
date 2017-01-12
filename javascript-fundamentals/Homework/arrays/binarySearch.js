'use strict';

function solve(args){
    let array = [];

    for(let i = 1, len = args.length - 1; i < len; i++){
        array.push(+args[i]);
    }

    // define binary search variables
    let targetValue = +args[args.length - 1],
        leftBoundary = 0,
        rightBoundary = array.length - 1,
        middle = 0;

    while(true){

        if(leftBoundary > rightBoundary){
            console.log(-1);
            break;
        }

        middle = Math.floor((leftBoundary + rightBoundary) / 2);

        if(array[middle] < targetValue){
            leftBoundary = middle + 1;
        } else if(array[middle] > targetValue){
            rightBoundary = middle - 1;
        } else {
            console.log(middle);
            break;
        }
    }
}

let arr = ['10', '1', '2', '4', '8', '16', '31', '32', '64', '77', '99', '32'];
solve(arr);
