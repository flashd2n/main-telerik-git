'use strict';

function solve(args){
    let nameInput = args[0];
    printHello(nameInput);

    function printHello(name){
        console.log(`Hello, ${name}!`);
    }
}
