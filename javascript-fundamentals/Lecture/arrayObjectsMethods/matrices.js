'use strict';


let rows = 5;
let cols = 5;

let field = new Array(rows);
field.fill(0); // some hack to get this to work lol
for(let i in field){
    field[i] = new Array(cols);
    field[i].fill(-1);
}
 
field[0][0] = 0;
field[0][1] = 1;
field[0][2] = 2;
field[0][3] = 3;
field[rows - 1][cols - 1] = 4;
field[rows - 1][cols - 2] = 5;
field[rows - 1][cols - 3] = 6;
field[rows - 1][cols - 4] = 7;

console.log(field