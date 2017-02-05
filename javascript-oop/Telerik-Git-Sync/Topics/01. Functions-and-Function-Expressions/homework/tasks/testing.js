'use strict';

function findPrimes(start, end) {
		let result = [];

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

	}

let finalResult = findPrimes(0, 5);
console.log(finalResult);