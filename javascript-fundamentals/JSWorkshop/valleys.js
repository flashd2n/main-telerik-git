'use strict';

function solve(args) {
    let heights = args[0].split(' '),
        result = 0,
        tempCount = 0;

    for (let i = 0; i < heights.length; i++) {
        heights[i] = Number(heights[i]);
    }

    for (let i = 0; i < heights.length; i++) {

        if (i === 0) {
            tempCount += heights[i];
        } else if (heights[i] > heights[i + 1] && heights[i] > heights[i - 1]) {

            tempCount += heights[i];

            if (tempCount > result) {
                result = tempCount;
            }
            tempCount = heights[i];
        } else {
            tempCount += heights[i];
        }
    }
    console.log(tempCount > result ? tempCount : result);
}

let input = ["5 1 7 4 8"];
solve(input);