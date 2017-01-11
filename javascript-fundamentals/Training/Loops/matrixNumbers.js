'use strict';

function solve(args){
    let number = +args[0],
        print = ``;

    for(let i = 1; i <= number; i++){
        for(let j = i; j < number + i; j++){
            print += `${j} `;
        }
        console.log(print);
        print = ``;
    }
}

let arr = ['3'];
solve(arr);