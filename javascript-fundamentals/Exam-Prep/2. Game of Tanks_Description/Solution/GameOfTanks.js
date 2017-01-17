'use strict';

function solve(args){
    //define field elements this is done to make writing and reading the code a bit easier.
    const DEBRIS = -1;
    const EMPTYFIELD = 10;

    //get field dimentions
    let dimentions = args[0].split(' ').map(Number);
    let totalRows = dimentions[0],
        totalCols = dimentions[1];
    
    // create field
    let field = new Array(totalRows);
    field.fill(0);
    for (let i = 0; i < field.length; i++) {
        field[i] = new Array(totalCols);
        field[i].fill(EMPTYFIELD);
    }    

    //get debris coordinates
    let debrisInput = args[1].split(';');
    
    // apply debris on field
    for(let i = 0; i < debrisInput.length; i++){
        let tempDebris = debrisInput[i].split(' ').map(Number);
        field[tempDebris[0]][tempDebris[1]] = DEBRIS;
    }
    
    // apply players on the field
    for(let i = 0; i <= 3; i++){ // these are Koceto's tanks
        field[0][i] = i;
    }
    let tempPos = 4;
    for(let i = totalCols - 1; i >= totalCols - 4; i--){ // these are Cuki's tanks
        field[totalRows - 1][i] = tempPos;
        ++tempPos;
    }

    // field done

    // set up system for storing the tank's IDs AND their positions
    let tankPositions = [
        {row: 0, col: 0},
        {row: 0, col: 1},
        {row: 0, col: 2},
        {row: 0, col: 3},
        {row: totalRows - 1, col: totalCols - 1},
        {row: totalRows - 1, col: totalCols - 2},
        {row: totalRows - 1, col: totalCols - 3},
        {row: totalRows - 1, col: totalCols - 4},
    ];

    let playersTanks = [4,4]; // total number of tanks per player -> playersTanks[0] is Koceto playersTanks[1] is Cuki

    //begin command processing

    let commandCount = +args[2];

    // loop cycles are equal to the number of commands

    for(let i = 0; i < commandCount; i++){
        let commandInput = args[3 + i].split(' ');

        if(commandInput[0] === 'mv'){
            // have to move a tank

            // get move commands
            let tankToMove = +commandInput[1],
                cellsToMove = +commandInput[2],
                moveDirection = commandInput[3] + '';

            //process move commands
        moveTank(tankToMove, cellsToMove, moveDirection);

        } else if(commandInput[0] === 'x'){ // have to shoot with a tank
            // get shoot commands
            let tankToShoot = +commandInput[1],
                shootDirection = commandInput[2] + '';

            //process shoot commands            
            shootWithTank(tankToShoot, shootDirection);
        }
    }


    function moveTank(id, numberOfCells, direction){
        let deltaRow = 0, deltaCol = 0;

        // delta pattern setup
        if(direction === 'u') {
        deltaRow = -1;
        }
        else if(direction === 'd') {
        deltaRow = 1;
        }
        else if(direction === 'l') {
        deltaCol = -1;
        }
        else if(direction === 'r') {
        deltaCol = 1;
        }

        // get coords of the tank to move
        let tankRow = tankPositions[id].row,
            tankCol = tankPositions[id].col;
        
        // "moving" a tank means two things -> 1-st you need to set the current position of the tank to an EMPTYFIELD and then you need to set the destination field to the ID of the tank.

        // setting the current field of the tank to EMPTYFIELD
        field[tankRow][tankCol] = EMPTYFIELD;

        while (numberOfCells > 0) {
            //move tank ONE cell at a time
            // calculate the next destination cell
            let tempRow = tankRow + deltaRow,
                tempCol = tankCol + deltaCol;

            // invalid move conditions
            if(field[tempRow][tempCol] !== EMPTYFIELD){
                break;
            }
            if(tempRow < 0 || tempRow > totalRows - 1){
                break;
            }
            if(tempCol < 0 || tempCol > totalCols - 1){
                break;
            }

            // if you are here, then the move command was valid
            tankRow = tempRow;
            tankCol = tempCol;

            --numberOfCells;
        }

        // here we have the final destination coordinates and we need to do 2 things: 1) update the new coordinates in the tankPositions array AND 2) set the value of the destination field cell to the tank ID

        tankPositions[id].row = tankRow;
        tankPositions[id].col = tankCol;

        field[tankRow][tankCol] = id;

    }

    function shootWithTank(id, direction){

        let deltaRow = 0, deltaCol = 0;

        // same delta pattern I used in the move function
        if(direction === 'u') {
        deltaRow = -1;
        }
        else if(direction === 'd') {
        deltaRow = 1;
        }
        else if(direction === 'l') {
        deltaCol = -1;
        }
        else if(direction === 'r') {
        deltaCol = 1;
        }

        // get coords of BULLET --> IMPORTANT!!!! when you have a "shoot" command, then your starting point is NOT the tank that shoots, your starting point is the cell NEXT to the tank who shoots, becuase if you do not do this you will kill your tank every time
        // in this fuction we will NOT calculate the movement of a tank, we will calculate the movement of a bullet ---> this means that we will get 1) The starting cell of the bullet 2) check the cell for a few conditions and 3) if the conditions are false, move the bullet to the next cell
        let bulletRow = tankPositions[id].row + deltaRow,
            bulletCol = tankPositions[id].col + deltaCol;
        
        // some people don't like writing "pseudo infinite loops" --- while statement with "true" condition, but I like it --- makes it easier for me to control the flow of the logic and the exit conditions
        while (true) {

            // check for exit conditions -> 1) if the bullet leaves the field -> we exit 2) if the bullet hits a DEBRIS we set that cell to EMPTYFIELD 3) if the bullet hits a tank we set that cell to EMPTYFIELD, reduce the tank count for that player and check for game ending condition
           if(bulletRow < 0 || bulletRow > totalRows - 1){
               break;
           } else if(bulletCol < 0 || bulletCol > totalCols - 1){
               break;
           } else if(field[bulletRow][bulletCol] === EMPTYFIELD){ // here the bullet lands on an empty field ---> we just update the next bullet coordinates and loop again ---> you see how useful the delta pattern is?
               // empty field

               bulletRow += deltaRow;
               bulletCol += deltaCol;
               continue;

           } else if(field[bulletRow][bulletCol] === DEBRIS){ // he hit a DEBRIS -> set the cell to EMPTYFIELD and terminate the loop ---> the bullet cannot continue after it hits something
               // debris

               field[bulletRow][bulletCol] = EMPTYFIELD;
               break;
           } else { // the last condition is the one where we hit a tank
               
               // we get the ID of the dead tank
               let enemyTankID = field[bulletRow][bulletCol];

               // set the field cell to EMPTYFIELD
               field[bulletRow][bulletCol] = EMPTYFIELD;

               // check whos tank we hit
               if(enemyTankID <= 3){
                   // koceto
                   console.log(`Tank ${enemyTankID} is gg`);

                   //remove one tank from the total count for koceto
                   --playersTanks[0];

                   //check to see if koceto has any tanks left
                   if(playersTanks[0] === 0){
                       console.log('Koceto is gg');
                   }
                   break;
               } else{
                   //cuki
                   console.log(`Tank ${enemyTankID} is gg`);

                   //remove one tank from the total count for cuki
                   --playersTanks[1];

                   //check to see if cuki has any tanks left
                   if(playersTanks[1] === 0){
                       console.log('Cuki is gg');
                   }
                   break;
               }
           }
        }
    }
}


solve([
    '10 5',
    '1 0;1 1;1 2;1 3;1 4;3 1;3 3;4 0;4 2;4 4',
    '43',
    'mv 6 5 r',
    'mv 0 6 d',
    'x 0 d',
    'x 0 d',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 7 u',
    'x 7 u',
    'x 7 u',
    'x 7 u',
    'x 7 u',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 4 u',
    'x 4 u',
    'x 4 u',
    'x 4 u',
    'x 4 u',
    'x 0 r',
    'mv 0 6 d',
    'mv 0 9 r',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d'
]);