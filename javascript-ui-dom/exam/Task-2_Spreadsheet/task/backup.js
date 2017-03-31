'use strict';

let rows = 42;
let columns = 20;

// let cellsMatrix = Array.from({length: rows});
// cellsMatrix.fill(Array.from({length: columns}));


let cellsMatrix = new Array(rows);
for(let i = 0; i < rows; i++){

	cellsMatrix[i] = new Array(columns);

}

		var testMatrix = [];

		for(let i = 0; i < rows; i++){

			// row = $(`table tr:eq(${i + 1})`);
			
			// testMatrix.push(row);

			for(let j = 0; j < columns; j++){

				// var $cell = row.find('td').eq(j);

				cellsMatrix[i][j] = `${i} : ${j}`;

			}

		}

console.log(cellsMatrix);