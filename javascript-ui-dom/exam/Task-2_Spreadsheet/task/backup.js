'use strict';

function solve() {

	return function (selector, rows, columns) {

		var $container = $(selector);

		var $table = $('<table>').addClass('spreadsheet-table');

		for (var i = 0; i <= rows; i++) {

			var $tableRow = $('<tr>');

			for (var j = 0; j <= columns; j++) {

				if (i === 0) {
					var $tableHeader = $('<th>').addClass('spreadsheet-header').addClass('spreadsheet-item');

					if (j === 0) {
						$tableHeader.appendTo($tableRow);
						continue;
					}

					$tableHeader.text(String.fromCharCode(65 + (j - 1)));
					$tableHeader.appendTo($tableRow);
					continue;
				}

				if (j === 0) {
					var $tableHeader = $('<th>').addClass('spreadsheet-header').addClass('spreadsheet-item');
					$tableHeader.text(i);
					$tableHeader.appendTo($tableRow);
					continue;
				}

				var $tableCell = $('<td>').addClass('spreadsheet-cell').addClass('spreadsheet-item');
				var $tableCellInput = $('<input>');
				$tableCellInput.appendTo($tableCell);
				var $tableCellSpan = $('<span>');
				$tableCellSpan.appendTo($tableCell);
				$tableCell.appendTo($tableRow);
			}

			$tableRow.appendTo($table);
		}
		$table.appendTo($container);

		// table built functionality next

		var row;

		var cellsMatrix = new Array(rows + 1);
		for (var i = 0; i <= rows; i++) {

			cellsMatrix[i] = new Array(columns + 1);

		}

		for (var i = 0; i <= rows; i++) {

			row = $(`table tr:eq(${i})`);

			for (var j = 0; j <= columns; j++) {

				var $cell = row.find('.spreadsheet-item').eq(j);

				cellsMatrix[i][j] = $cell;
			}
		}

		// selection
		var startCol;
		var startRow;
		var $cellStart;


		var down = false;
		$(document).mousedown(function (event) {

			$cellStart = $(event.target);

			startCol = findCelCol($cellStart);
			startRow = findCelRow($cellStart);


			down = true;
		}).mouseup(function () {
			down = false;
		});

		var dragTargetNew;
		var dragTargetPrevious;

		var $allItems = $('.spreadsheet-item');
		$allItems.on('mousemove', function (event) {


			dragTargetNew = event.target;

			if (down && (dragTargetNew !== dragTargetPrevious)) {

				var element = $(dragTargetNew);


				if ($cellStart.hasClass('spreadsheet-cell')) {

					multipleCellSelection(this);

				} else {

					multipleHeaderSelection(this);

				}

			}

			dragTargetPrevious = event.target;

		});

		// single cell selection
		var $allCells = $('.spreadsheet-cell');
		$allCells.on('mousedown', function () {

			cellSelection(this);

		});



		var $allTableHeaders = $('.spreadsheet-header');
		$allTableHeaders.on('mousedown', function () {

			headerSelection(this);

		});

		var $topLeftCell = $('.spreadsheet-table tr:first').find('th:first');
		$topLeftCell.on('mousedown', function () {

			var $allItems = $('.spreadsheet-item');
			$allItems.addClass('selected');

		});


		// enable editing

		$allCells.on('dblclick', function () {

			var $cell = $(this);
			$cell.addClass('editing');
			$cell.children('input').focus();

			var $span = $cell.children('span');
			var currentValue = $span.text();
			var $inputElement = $cell.children('input');
			$inputElement.val(currentValue);

			$inputElement.on('blur', function () {

				$cell.removeClass('editing');
				var valueInput = $inputElement.val();
				$span.text(valueInput);

			});

		});



		$.fn.selectCell = function (cellRow, cellCol) {

			cellsMatrix[cellRow][cellCol].addClass('selected');
			cellsMatrix[0][cellCol].addClass('selected');
			cellsMatrix[cellRow][0].addClass('selected');

			return this;
		}

		function cellSelection(context) {

			$('.selected').removeClass('selected');
			var $currentCell = $(context);

			var cellRow = findCelRow($currentCell);
			var cellCol = findCelCol($currentCell);

			$(context).selectCell(cellRow, cellCol);
		}

		function multipleHeaderSelection(context) {
			var $currentHeader = $(context);
			// startCol
			var headerCol = $currentHeader.index();
			var headerRow = findHeaderRow($currentHeader);

			if (headerRow === -1) {

				if (startCol > headerCol) {

					for (var i = headerCol; i <= startCol; i++) {

						PureHeaderSelection(cellsMatrix[0][i]);

					}
				} else {
					for (var i = startCol; i <= headerCol; i++) {

						PureHeaderSelection(cellsMatrix[0][i]);

					}
				}
			} else if(headerRow >= 1) {
				PureHeaderSelection(cellsMatrix[headerRow][0]);
				
			}


		}

		function multipleCellSelection(context) {
			// startCol
			// startRow
			var $currentCell = $(context);
			var currentCellRow = findCelRow($currentCell);
			var currentCellCol = findCelCol($currentCell);


			$currentCell.selectCell(currentCellRow, currentCellCol);

			cellsMatrix[2][3].selectCell(2, 3);

			if (startRow > currentCellRow && startCol !== currentCellCol) {

				for (var i = currentCellRow; i <= startRow; i++) {
					cellsMatrix[i][currentCellCol].selectCell(i, currentCellCol);
				}

			} else {
				for (var i = startRow; i <= currentCellRow; i++) {
					cellsMatrix[i][currentCellCol].selectCell(i, currentCellCol);
				}

			}

			if (startCol > currentCellCol && startRow !== currentCellRow) {

				for (var i = currentCellCol; i <= startCol; i++) {
					cellsMatrix[currentCellRow][i].selectCell(currentCellRow, i);
				}

			} else {

				for (var i = startCol; i <= currentCellCol; i++) {
					cellsMatrix[currentCellRow][i].selectCell(currentCellRow, i);
				}

			}

		}

		function headerSelection(context) {

			$('.selected').removeClass('selected');
			var $header = $(context);
			var headerRow = findHeaderRow($header);
			var headerCol = $header.index();
			var isLetter = checkHeader($header);

			if (!isLetter) {

				for (var i = 0; i <= columns; i++) {
					cellsMatrix[headerRow][i].selectCell(headerRow, i);
				}

			} else {

				for (var i = 0; i <= rows; i++) {
					cellsMatrix[i][headerCol].selectCell(i, headerCol);
				}
			}
		}

		function PureHeaderSelection(context) {
			var $header = $(context);
			var headerRow = findHeaderRow($header);
			var headerCol = $header.index();
			var isLetter = checkHeader($header);

			if (!isLetter) {

				for (var i = 0; i <= columns; i++) {
					cellsMatrix[headerRow][i].selectCell(headerRow, i);
				}

			} else {

				for (var i = 0; i <= rows; i++) {
					cellsMatrix[i][headerCol].selectCell(i, headerCol);
				}
			}
		}

		function checkHeader($header) {

			var $cellSiblings = $header.siblings('td');
			if ($cellSiblings.length === 0) {
				return true;
			} return false;
		}

		function findCelRow($cell) {

			var $currentHeader = $cell;
			var currentHeaderIndex = $currentHeader.index();
			var $currentEntireCol = $('tr').find('td:eq(' + (currentHeaderIndex - 1) + ')');

			var cellRow = 1 + ($currentEntireCol.index($cell));

			return cellRow;
		}

		function findCelCol($cell) {
			return $cell.index();
		}

		function findHeaderRow($header) {
			var $currentHeader = $header;
			var currentHeaderIndex = $currentHeader.index();
			var $currentEntireCol = $('tr').find('th:eq(' + (currentHeaderIndex - 1) + ')');

			var cellRow = $currentEntireCol.index($header);

			return cellRow;
		}

	};
}

// SUBMIT THE CODE ABOVE THIS LINE

if (typeof module !== 'undefined') {
	module.exports = solve;
}


