'use strict';

function solve(args){
    let field = args.map(Number);
    let totalCells = field[0],
        currentCell = 1,
        result = 0;

    if(totalCells > 1){
        result = field[currentCell] % 1024;
        if(field[currentCell] % 2 === 0){
            AddCellTwo();
        } else{
            AddCellOne();
        }
    }

    while (currentCell <= totalCells) {
        
        if(field[currentCell] % 2 === 0){

            CalculateResultAddition();
            AddCellTwo();
        } else{
            CalculateResultMulti();
            AddCellOne();
        }
    }
    console.log(result);



    function CalculateResultAddition(){
        result = (result + field[currentCell]) % 1024;
    }

    function CalculateResultMulti(){
        result = (result * field[currentCell]) % 1024;
    }

    function AddCellTwo(){
        currentCell += 2;
    }

    function AddCellOne(){
        ++currentCell;
    }
}


solve([
  '9',
  '9',
  '9',
  '9',
  '9',
  '9',
  '9',
  '9',
  '9',
  '9'
]);