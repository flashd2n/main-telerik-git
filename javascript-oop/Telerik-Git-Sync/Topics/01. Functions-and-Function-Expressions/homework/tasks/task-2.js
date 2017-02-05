/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

'use strict';

function solve() {
	return function findPrimes(start, end) {
		let result = [];

		if(isNaN(start) || isNaN(end)){
			throw new Error('Range params is not a number');
		}
		start = +start;
		end = +end;

		for(let i = start; i <= end; i++){
			if(isPrime(i)){
				result.push(i);
			}
		}

		function isPrime(x){

			if(x === 0 || x === 1){
                return false;
            }

			for(let i = 2; i <= Math.sqrt(x); i++){
				if(x % i === 0){
					return false;
				}
			}
			return true;
		}

		return result;

	};
}

module.exports = solve;
