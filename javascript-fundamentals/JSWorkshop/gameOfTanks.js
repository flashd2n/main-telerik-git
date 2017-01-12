'use strict';

function solve(args){
    let fieldSizes = args[0].split(' ').map(Number);
    // get field size
    let field = [];
    // get debris
    let debrisCoordsInput = args[1].split(`;`);
    let debrisCoords = [];

    for(let i = 0; i < debrisCoordsInput.length; i++){
        debrisCoords[i] = debrisCoordsInput[i].split(' ').map(Number);
    }

    for(let i = 0; i < fieldSizes[0]; i++){
        field[i] = [];
        for(let j = 0; j < fieldSizes[1]; j++){
                field[i][j] = `-`;
        }
    }
    // set player positions
    field[0][0] = 0;
    field[0][1] = 1;
    field[0][2] = 2;
    field[0][3] = 3;
    field[fieldSizes[0] - 1][fieldSizes[1] - 1] = 4;
    field[fieldSizes[0] - 1][fieldSizes[1] - 2] = 5;
    field[fieldSizes[0] - 1][fieldSizes[1] - 3] = 6;
    field[fieldSizes[0] - 1][fieldSizes[1] - 4] = 7;
    //apply debris on field
    for(let i = 0; i < debrisCoords.length; i++){
        field[debrisCoords[i][0]][debrisCoords[i][1]] = '#';
    }
    //field ready
    let numberCommands = Number(args[2]);

    while (numberCommands !== 0) {
        //get command

        //process command




        --numberCommands;
    }


}

let test = ['5 5', '2 0;2 1;2 2;2 3;2 4', '13'];
solve(test);