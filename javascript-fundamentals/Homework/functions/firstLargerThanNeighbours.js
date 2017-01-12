'use strict';

function solve(args){
    let size = Number(args[0]);
    let array = args[1].split(' ').map(Number);

    let result = GetFirstNeighbour(array, size);
    console.log(result);

    function GetFirstNeighbour(array, size){
        for(let i = 0; i < size; i++){
            if(i !== 0 && i !== size - 1 && array[i] > array[i - 1] && array[i] > array[i + 1]){
                return i;
            }
        }
    }
}