'use strict';

function solve(args){
    let arraySize = Number(args[0]),
        array = args[1].split(' '),
        targetNumber = Number(args[2]);

        console.log(GetOccurencesCount(array, targetNumber));

    function GetOccurencesCount(array, targetNumber){
        let occurences = 0;

        for(let i = 0; i < array.length; i++){
            if(+array[i] === targetNumber){
                ++occurences;
            }
        }
        return occurences;
    }
}

let input = [ '8', '28 6 21 6 -7856 73 73 -56', '73' ];
solve(input);