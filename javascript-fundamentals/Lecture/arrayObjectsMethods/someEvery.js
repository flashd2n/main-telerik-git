'use strict';

let array = [1,2,3,4,5,6,7,8,9,10];

let array2 = [2,4,6,8];

array2.reverse();

function isEven(x){
    return x % 2 === 0;
}

function isLess10(x){
    return x < 10;
}
function IsIncreasing(x, i, arr){
    if(i === 0){
        return true;
    } else if(x > arr[i - 1]){
        return true;
    } else{
        return false;
    }
}


let result = array.some(isLess10);
let result2 = array2.some(isLess10);
console.log(result);
console.log(result2);
console.log(`====`);
let result3 = array2.every(IsIncreasing);
console.log(result3);


