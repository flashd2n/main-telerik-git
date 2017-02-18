'use strict';

let person = {
    name: `gosho`,
    address: {
        city: `Sofia`,
        street: `Some street`
    },
    [Symbol.iterator]: function () {
        return iterate(this);
    }
};


function* iterate(obj) {
    for (const key in obj) {
        if (typeof obj[key] === `object`) {
            yield* iterate(obj[key]);
        } else {
            yield `${key}: ${obj[key]}`;
        }
    }
}

// for (let i in person) {
//     console.log(person[i]);
// }

for (let element of person) {
    console.log(element);
}