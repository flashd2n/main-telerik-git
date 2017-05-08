'use strict';

let calc = {
    sum(...numbers) {
        return numbers.reduce((sum, number) => sum + number, 0);
    },
    multiply(...numbers) {
        return numbers.reduce((product, number) => product * number, 1);
    }
};

//module.exports = {
//    calc
//};


class Calculator {
    constructor() {
        this._value = 0;
    }

    sum(...numbers) {
        numbers.forEach(number => this._value += number);
    }
}


export {
    Calculator,
    calc
};

export default new Calculator();
