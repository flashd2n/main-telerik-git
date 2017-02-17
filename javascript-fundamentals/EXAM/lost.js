'use strict';

function solve(args){
    let mazeDimentions = args[0].split(' ').map(Number),
        mazeRows = mazeDimentions[0],
        mazeCols = mazeDimentions[1];

    let maze = new Array(mazeRows);
    maze.fill(0);
    for(let i = 0; i < mazeRows; i++){
        maze[i] = args[i + 1].split(' ').map(Number);
    }

    // basic maze completed

    let checkMaze = new Array(mazeRows);
    checkMaze.fill(0);
    for(let i = 0; i < mazeRows; i++){
        checkMaze[i] = new Array(mazeCols);
        checkMaze[i].fill(true);
    }

    // check maze completed

    let currentRow = Math.round((mazeRows - 1) / 2),
        currentCol = Math.round((mazeCols - 1) / 2);
    
    

    while (true) {        
        let cellID = maze[currentRow][currentCol];
        // starting positions set
        let upCondition = cellID & 1,
        rightCondition = (cellID & (1 << 1)) >> 1,
        downcondition = (cellID & (1 << 2)) >> 2,
        leftcondition = (cellID & (1 << 3)) >> 3;
        // execute move command

        // check for exit here and continue if definitely no exit

        if(upCondition === 1 && currentRow === 0){
            console.log(`No rakiya, only JavaScript ${currentRow} ${currentCol}`);
            break;
        } else if((rightCondition === 1) && currentCol === mazeCols - 1){
            console.log(`No rakiya, only JavaScript ${currentRow} ${currentCol}`);
            break;
        } else if((downcondition === 1) && currentRow === mazeRows - 1){
            console.log(`No rakiya, only JavaScript ${currentRow} ${currentCol}`);
            break;
        } else if((leftcondition === 1) && currentCol === 0){
            console.log(`No rakiya, only JavaScript ${currentRow} ${currentCol}`);
            break;
        }

        // 2 options here -> valid move or no moves at all

        if((upCondition === 1) && checkMaze[currentRow - 1][currentCol] === true){
            // up movement possible
            checkMaze[currentRow][currentCol] = false;
            currentRow -= 1;
            continue;
        } else if((rightCondition === 1) && checkMaze[currentRow][currentCol + 1] === true){
            // right movement possible
            checkMaze[currentRow][currentCol] = false;
            currentCol += 1;
            continue;
        } else if((downcondition === 1) && checkMaze[currentRow + 1][currentCol] === true){
            // down movement possible
            checkMaze[currentRow][currentCol] = false;
            currentRow += 1;
            continue;
        } else if((leftcondition === 1) && checkMaze[currentRow][currentCol - 1] === true){
            // left movement possible
            checkMaze[currentRow][currentCol] = false;
            currentCol -= 1;
            continue;
        } else{
            // no possible moves
            console.log(`No JavaScript, only rakiya ${currentRow} ${currentCol}`);
            break;
        }

    }
}


 solve([
    '7 5',
    '9 3 11 9 3',
    '10 12 4 6 10',
    '12 3 13 1 6',
    '9 6 11 12 3',
    '10 9 6 13 6',
    '10 12 5 5 3',
    '12 5 5 5 6'
]);