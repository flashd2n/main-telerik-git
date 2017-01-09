'use strict';

function solve(args){
    let x = Number(args[0]),
        y = Number(args[1]),
        r = 1.5 * 1.5;
    
    let isCircle = `outside circle`;

    if((x - 1) * (x - 1) + (y - 1) * (y - 1) <= r){
        isCircle = `inside circle`;
    }

    let isRec = `outside rectangle`;

    if((x >= -1 && x <= 4) && (y >= -1 && y <= 1)){
        isRec = `inside rectangle`;
    }

    console.log(`${isCircle} ${isRec}`);

}