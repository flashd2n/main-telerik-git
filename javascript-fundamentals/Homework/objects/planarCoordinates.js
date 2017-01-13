'use strict';

function solve(args){
    //build lines
    let lineOne = BuildLine([+args[0], +args[1]], [+args[2], +args[3]]),
        lineTwo = BuildLine([+args[4], +args[5]], [+args[6], +args[7]]),
        lineThree = BuildLine([+args[8], +args[9]], [+args[10], +args[11]]);
    // get lines' length
    let lineOneLength = GetLineLength(lineOne),
        lineTwoLength = GetLineLength(lineTwo),
        lineThreeLength = GetLineLength(lineThree);

        console.log(lineOneLength.toFixed(2));
        console.log(lineTwoLength.toFixed(2));
        console.log(lineThreeLength.toFixed(2));

        if(CheckTriangle()){
            console.log('Triangle can be built');
        } else{
            console.log('Triangle can not be built');
        }

    function CheckTriangle(){
        if(lineOneLength + lineTwoLength > lineThreeLength && lineTwoLength + lineThreeLength > lineOneLength && lineThreeLength + lineOneLength > lineTwoLength){
            return true;
        } else{
            return false;
        }
    }
    function GetLineLength(line){
        let a = Math.abs(line.x[0] - line.y[0]),
            b = Math.abs(line.x[1] - line.y[1]);
        let result = Math.sqrt(a * a + b * b);
        return result;       
    }
    function BuildLine(x, y){
        return {
            x: x,
            y: y
        }
    }
}


solve([
  '5', '6', '7', '8',
  '1', '2', '3', '4',
  '9', '10', '11', '12'
]);