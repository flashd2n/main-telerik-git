'use strict';

function solve(args){

    let input = args.split(' ');
    let bigger = GetMax(GetMax(+input[0], +input[1]), +input[2]);

    console.log(bigger);

    function GetMax(a, b){
        if(a > b){
            return a;
        } else{
            return b;
        }
    }
}

let input = '8 19 19';
solve(input);