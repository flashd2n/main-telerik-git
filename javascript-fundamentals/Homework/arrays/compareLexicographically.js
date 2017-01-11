'use strict';

function solve(args){
    let stringOne = String(args[0]),
        stringTwo = String(args[1]);

    let shorterString = 0;

    if(stringOne.length > stringTwo.length){
        shorterString = stringTwo.length;
    } else {
        shorterString = stringOne.length;
    }

    for(let i = 0; i < shorterString; i++){
        if(stringOne.charAt(i) > stringTwo.charAt(i)){
            console.log(`>`);
            break;
        } else if(stringOne.charAt(i) < stringTwo.charAt(i)){
            console.log(`<`);
            break;
        }
        // if the strings are equal until the last loop -> check strings length
        if(i === (shorterString - 1)){
            if(stringOne.length > stringTwo.length){
                console.log(`>`);
                break;
            } else if(stringOne.length < stringTwo.length){
                console.log(`<`);
                break;
            } else{
                console.log(`=`);
                break;
            }
        }
    }
}
let str1 = "hello";
let str2 = "hell";
console.log(str1.localeCompare(str2));