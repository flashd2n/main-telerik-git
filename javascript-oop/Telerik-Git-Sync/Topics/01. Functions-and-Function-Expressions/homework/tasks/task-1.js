/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/

'use strict';

function solve() {
	return function sum(array) {

		if(array.length === 0){
			return null;
		}

		array.forEach(function(x){
			if(isNaN(x)){
				throw new Error('This is not a number');
			}
		});

		let result = array.reduce((x,y) => +x + +y, 0);
		return result;

	}
}

module.exports = solve;