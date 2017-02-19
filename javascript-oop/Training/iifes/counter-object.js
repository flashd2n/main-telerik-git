'use strict';

const counter = (function(){
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
})();



console.log(counter.getNext());
console.log(counter.getNext());
console.log(counter.getNext());
console.log(counter.getNext());
counter.resetCounter();
console.log(counter.getNext());
console.log(counter.getNext());
console.log(counter.getNext());
console.log(counter.getNext());