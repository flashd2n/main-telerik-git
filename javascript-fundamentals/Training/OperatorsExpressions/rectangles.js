'use strict';

function solve(args){
    let width = Number(args[0]),
        height = Number(args[1]);
    
    let area = width * height;
    let perimeter = width * 2 + height * 2;
    console.log(`${area.toFixed(2)} ${perimeter.toFixed(2)}`);
}