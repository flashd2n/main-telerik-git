'use strict';

function solve(args) {
    var arr = [],
        num = +args[0];

    for (var i = num; i >= 2; i--) {
        if (isPrime(i)) {
            return i;
        }
    }



    function isPrime(num) {
        if (num < 2) {
            return false;
        }
        for (var i = 2; i <= num / 2; i++) {
            if (num % i === 0) {
                return false;
            }
        }
        return true;
    }
}


