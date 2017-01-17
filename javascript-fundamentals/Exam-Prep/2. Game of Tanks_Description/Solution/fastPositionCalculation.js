'use strict';


let fieldRow = 5;
let fieldCol = 5;

let field = new Array(fieldRow);

field.fill(0);

for(let i = 0; i < field.length; i++){
    field[i] = new Array(fieldCol);
    field[i].fill(0);
}

let player = [1, 0];
let playerRow = player[0];
let playerCol = player[1];
field[playerRow][playerCol] = '#';



// we have a field with sizes: fieldRow and fieldCol
// we have a player, who is makerd with '#' on playerRow and playerCol


console.log('Initial Field');
console.log(field);
// move 6 times to the right, if you leave the field -> continue from the other side
// we can move 4 times to the right and we will be on the last cell of the row with coords [1, 4], right?
// the other 2 moves will begin from the start of the current col, so we want to end up in cell [1, 2] ---> something like overflowing

field[playerRow][playerCol] = 0;

playerCol = (playerCol + 6) % fieldCol; // WHEN MOVING TO THE RIGHT (MAKING POSITIVE CHANGE) you just add the steps
if(playerCol < 0){
    playerCol += fieldCol;
}

field[playerRow][playerCol] = '#';


console.log('Field after moving the players 6 times to the right');
console.log(field);

field[playerRow][playerCol] = 0;

playerCol = (playerCol - 6) % fieldCol; // WHEN MOVING TO THE LEFT (MAKING NEGATIVE CHANGE) you just deduct the steps
if(playerCol < 0){
    playerCol += fieldCol;
}

field[playerRow][playerCol] = '#';

console.log('Field after moving the player 6 times to the left');
console.log(field);

// this is very fast, because it is just an expression which calculates the end position instantly
// the other way is to make loops to calculate the end position