'use strict';

function solve(args) {
    let a = Number(args[0]),
        b = Number(args[1]),
        c = Number(args[2]),
        d = (b * b) - 4 * a * c;
    
    if(d > 0){
        let xOne = (-b - Math.sqrt(d)) / (2 * a);
        let xTwo = (-b + Math.sqrt(d)) / (2 * a);
        
        if(xOne < xTwo)
        {
            console.log(`x1=${xOne.toFixed(2)}; x2=${xTwo.toFixed(2)}`);
        } else
        {
            console.log(`x1=${xTwo.toFixed(2)}; x2=${xOne.toFixed(2)}`);
        }
        
    } else if(d === 0){
        let x = -b / (2 * a);
        console.log(`x1=x2=${x.toFixed(2)}`);
    } else {
        console.log(`no real roots`);
    }
}
