'use strict';

let point = {
    x: 1,
    y: 2
};

if (`x` in point) {
    console.log(`Yes, there is x in point`);
} else{
    console.log(`No, there isn't x in point`);
}


let myArray = [1,2,3,4,5];
delete myArray[2];
console.log(myArray);

let myObject = {
    x: 1,
    y: 2,
    z: 3
};

delete myObject.a;
console.log(myObject);