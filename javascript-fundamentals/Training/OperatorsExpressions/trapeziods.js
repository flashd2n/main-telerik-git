'use strict';

function solve(args){
    let a = Number(args[0]),
        b = Number(args[1]),
        h = Number(args[2]);
    
    let area = ((a + b) / 2) * h;
    console.log(area.toFixed(7));
}