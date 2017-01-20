'use strict';

function solve(args){
    let DEBRIS = -1,
        EMPTYCELL = 9;

    let fieldDimentions = args[0].split(' ').map(Number),
        fieldRows = fieldDimentions[0],
        fieldCols = fieldDimentions[1];
    
    let field = new Array(fieldRows);
    field.fill(0);
    for(let i = 0; i < fieldRows; i++){
        field[i] = new Array(fieldCols);
        field[i].fill(EMPTYCELL);
    }

    let debrisLocation = args[1].split(';');

    for(let i = 0; i < debrisLocation.length; i++){
        let tempDebris = debrisLocation[i].split(' ').map(Number);
        field[tempDebris[0]][tempDebris[1]] = DEBRIS;
    }

    for(let i = 0; i <= 3; i++){
        field[0][i] = i;
    }
    let cukiStart = 4;
    for(let i = fieldCols - 1; i >= fieldCols - 4; i--){
        field[fieldRows - 1][i] = cukiStart;
        ++cukiStart;
    }
    
    let tankPositions = [
        {row: 0, col: 0},
        {row: 0, col: 1},
        {row: 0, col: 2},
        {row: 0, col: 3},
        {row: fieldRows - 1, col: fieldCols - 1},
        {row: fieldRows - 1, col: fieldCols - 2},
        {row: fieldRows - 1, col: fieldCols - 3},
        {row: fieldRows - 1, col: fieldCols - 4},
    ];

    let playersTanks = [4, 4];
    //field complete

    let commandCount = +args[2];

    for(let i = 0; i < commandCount; i++){
        let commandInput = args[3 + i].split(' ');
        
        if(commandInput[0] === 'mv'){
            // move
            let tankID = +commandInput[1],
                numberOfCells = +commandInput[2],
                direction = commandInput[3];

            executeMove(tankID, numberOfCells, direction);

        } else{
            // shoot
            let tankID = +commandInput[1],
                direction = commandInput[2];

            executeShoot(tankID, direction);

        }
    }

    function executeMove(id, numberOfCells, direction){
        let deltaRows = 0,
            deltaCols = 0;

        if(direction === 'u'){
            deltaRows = -1;
        } else if(direction === 'd'){
            deltaRows = 1;
        } else if(direction === 'l'){
            deltaCols = -1;
        } else if(direction === 'r'){
            deltaCols = 1;
        }

        let tankRow = tankPositions[id].row,
            tankCol = tankPositions[id].col;
        
        field[tankRow][tankCol] = EMPTYCELL;

        while (numberOfCells > 0) {
            
            let tempRow = tankRow + deltaRows,
                tempCol = tankCol + deltaCols;
            
            if(tempRow < 0 || tempRow > fieldRows - 1){
                break;
            } else if(tempCol < 0 || tempCol > fieldCols - 1){
                break;
            } else if(field[tempRow][tempCol] !== EMPTYCELL){
                break;
            } else{
                tankRow = tempRow;
                tankCol = tempCol;
            }

            --numberOfCells;
        }

        tankPositions[id].row = tankRow;
        tankPositions[id].col = tankCol;

        field[tankRow][tankCol] = id;

    }

    function executeShoot(id, direction){
        let deltaRows = 0,
            deltaCols = 0;

        if(direction === 'u'){
            deltaRows = -1;
        } else if(direction === 'd'){
            deltaRows = 1;
        } else if(direction === 'l'){
            deltaCols = -1;
        } else if(direction === 'r'){
            deltaCols = 1;
        }

        let bulletRow = tankPositions[id].row + deltaRows,
            bulletCol = tankPositions[id].col + deltaCols;
        
        while (true) {
            
            if(bulletRow < 0 || bulletRow > fieldRows - 1){
                break;
            } else if(bulletCol < 0 || bulletCol > fieldCols - 1){
                break;
            } else if(field[bulletRow][bulletCol] === EMPTYCELL){
                bulletRow += deltaRows;
                bulletCol += deltaCols;
                continue;
            } else if(field[bulletRow][bulletCol] === DEBRIS){
                field[bulletRow][bulletCol] = EMPTYCELL;
                break;
            } else{
                let deadTankID = field[bulletRow][bulletCol];

                field[bulletRow][bulletCol] = EMPTYCELL;

                console.log(`Tank ${deadTankID} is gg`);

                if(deadTankID <= 3){
                    //koceto
                    
                    --playersTanks[0];
                    if(playersTanks[0] === 0){
                        console.log(`Koceto is gg`);
                    }


                } else{
                    //cuki
                    --playersTanks[1];
                    if(playersTanks[1] === 0){
                        console.log(`Cuki is gg`);
                    }
                }

                break;
            }



        }



    }


}

solve([
    '5 5',
    '2 0;2 1;2 2;2 3;2 4',
    '13',
    'mv 7 2 l',
    'x 7 u',
    'x 0 d',
    'x 6 u',
    'x 5 u',
    'x 2 d',
    'x 3 d',
    'mv 4 1 u',
    'mv 4 4 l',
    'mv 1 1 l',
    'x 4 u',
    'mv 4 2 r',
    'x 2 d'
]);

