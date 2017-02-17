'use strict';

let arr = [1, 2, 3];

let [x, y, z] = arr;

console.log(x);
console.log(y);
console.log(z);

console.log(`=====`);

let person = {
    name: `gosho`,
    address: {
        city: `Sofia`,
        street: `Some street`
    }
};

let {name, address, address: {city, street}} = person;

console.log(name);
console.log(address);
console.log(city);
console.log(street);

function add(...args){
    console.log(args);
    console.log(args.reduce((x, y) => x + y, 0));
    reverse(...args);
}

function reverse(args){
    for(let i = 0; i < arguments.length; i++){
        console.log(arguments[i]);
    }
}

add(1,4,5,7,8,9);
