'use strict';

function solve(args){
    let input = args[0].split(', ').map(Number);
    let targetSum = Number(args[1]);
    let startIndex = 0;
    let endIndex = 0;
    let result = '';
    
    result = GetSumSequence();
    console.log(result);


    function GetSumSequence(){
        for(let i = 0, len = input.length; i < len; i++){
            let tempSum = input[i];
            for(let j = i + 1; j < len; j++){

                tempSum += input[j];

                if(tempSum === targetSum){
                    startIndex = i;
                    endIndex = j;
                    result = input.slice(startIndex, endIndex + 1).join(', ');
                    return result;
                } else if(tempSum > targetSum){
                    break;
                }
            }
            if(i === len - 1 && tempSum !== targetSum){
                result = 'not found';
                return result;
            }
        }
    }
}

solve(['4, 3, 1, 4, 2, 5, 8', '11']);