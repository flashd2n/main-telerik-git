'use strict';

function myCounterModule(){
    let counter = 0;
    function getNext(){
        ++counter;
        return counter;
    }
    function resetCounter(){
        counter = 0;
    }

    return{
        getNext: getNext,
        resetCounter: resetCounter
    };
}

const counterOne = myCounterModule();
const counterTwo = myCounterModule();

console.log(counterOne.getNext());
console.log(counterOne.getNext());
console.log(counterOne.getNext());
console.log(`=== second counter ===`);
console.log(counterTwo.getNext());
console.log(counterTwo.getNext());
console.log(counterTwo.getNext());
console.log(`=== resume first counter ===`);
console.log(counterOne.getNext());
console.log(counterOne.getNext());
console.log(counterOne.getNext());