'use strict';

function solve(args){
    let hexadecimal = args[0],
    hexValue = 0,
    result = 0;

    for(let i = 0; i < hexadecimal.length; i++){
        if(isNaN(hexadecimal[i])){
            hexValue = hexadecimal.charCodeAt(i) - 55;
            result = result * 16 + hexValue;
        } else{
            result = (result * 16) + (hexadecimal.charCodeAt(i) - 48);
        }
    }
    console.log(result);
}


let arr = ['FE'];
solve(arr);