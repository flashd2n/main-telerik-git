'use strict';

function solve(args){
    let number = Number(args[0]);

    if(number === 0 || number < 0 || number === 1){
        console.log(`false`);
    } else{
        let isPrime = true;
        for(let i = 2; i < number; i++){
            if(number % i === 0){
                isPrime = false;
            }
        }

        if(isPrime){
            console.log(`true`);
        } else{
            console.log(`false`);
        }

    }
}