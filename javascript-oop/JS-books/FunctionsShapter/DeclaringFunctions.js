'use strict';

// standard declaration

function printStuff(x){
    console.log(x);
}


printStuff(`sometting cool`);


// expression declaration

let myFuction = function(x){console.log(x);};

myFuction(`function expression`);

// IIFE

(function(x){console.log(x)})(`IIFE declaration`);

(function(){console.log(`parameterless IIFE`);})();

