'use strict';

function solve() {

	let array = [].slice.call(arguments);

	return function sum() {

		let result = array.reduce((x,y) => x + y);
		return result;

	};
}

console.log(solve([1, 2, 3]));