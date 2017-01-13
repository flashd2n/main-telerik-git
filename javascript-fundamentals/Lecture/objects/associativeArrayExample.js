'use strict';

const wordArray = `word pesho number word pesho word word monkey vsetaya`.split(' ');

console.log(`word array -> ${wordArray}`);

let words = {};

for(let word of wordArray){

    if(words.hasOwnProperty(word)){ // the check can be done this way too ----> words[word] === undefined (but reverse if else)
        words[word] += 1;
    } else{
        words[word] = 1;
    }
}

console.log(words);

console.log(`=====`);

let arrayOfOccurences = [];

for(let item in words){
    arrayOfOccurences.push(words[item]);
}

console.log(`array of occurences -> ${arrayOfOccurences}`);


console.log(Object.keys(words)); // return array with all keys 