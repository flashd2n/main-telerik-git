'use strict';

function solve(array) {
    let len = +array[0];
    let arr = array[1].split(' ').map(Number);
    let arr2 = SortArray(arr, len);
    let result = arr2.join(' ');
    console.log(result);

    
    function SortArray(array, length) {
        let iNum, minNum, indexMin;
        for (let i = 0; i < len; i++) {
            iNum = +array[i];

            for (let j = i + 1; j <= len; j++) {

                if (iNum >= +array[j]) {
                    minNum = +array[j];
                    iNum = minNum;
                    indexMin = j;
                }
            }
            if (iNum != +array[i]) {
                temp = minNum;
                array[indexMin] = +array[i];
                array[i] = minNum;
            }
        }

        return array;
    }
}

solve(['10', '36 10 1 34 28 38 31 27 30 20'])