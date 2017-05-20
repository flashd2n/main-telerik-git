'use strict';

function sum(...numbers) {
    return numbers.reduce((x, y) => x + y, 0);
}


const funcs = {
    sum
};

console.log(funcs);

function action(numbers) {

    console.log(funcs.sum(4, 5));

}


module.exports = {
    action,
    funcs
};
