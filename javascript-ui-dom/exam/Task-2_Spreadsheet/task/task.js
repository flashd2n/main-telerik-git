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

		// selection

		var $allHeadersTop = $('.spreadsheet-table > tr:first th');

		// single cell selection
		var $allCells = $('.spreadsheet-cell');
		$allCells.on('mousedown', function () {

			var $allSelectedElements = $('.selected').removeClass('selected');


			var $cell = $(this).selectCell();

			// selectCell($cell);


		});

		var $allTableHeaders = $('.spreadsheet-header');
		$allTableHeaders.on('mousedown', function (event) {

			var $allSelectedElements = $('.selected').removeClass('selected');
			var $header = $(this);
			var isLetter = checkHeader($header);

			if (!isLetter) {

				var $entireRow = $header.siblings();
				$entireRow.each(function (cell) {

					var $cell = $(this).selectCell();

				});
			} else {

				var headerIndex = $header.index();
				var $entireCol = $('tr').find('td:eq(' + (headerIndex - 1) + ')');
				$entireCol.each(function () {

					var $cell = $(this).selectCell();

				});
			}

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

		// FUCK THIS

		var table = $("table");

		var isMouseDown = false;
		var startRowIndex = null;
		var startCellIndex = null;

		function selectTo(cell) {

			var row = cell.parent();
			var cellIndex = cell.index();
			var rowIndex = row.index();

			var rowStart, rowEnd, cellStart, cellEnd;

			if (rowIndex < startRowIndex) {
				rowStart = rowIndex;
				rowEnd = startRowIndex;
			} else {
				rowStart = startRowIndex;
				rowEnd = rowIndex;
			}

			if (cellIndex < startCellIndex) {
				cellStart = cellIndex;
				cellEnd = startCellIndex;
			} else {
				cellStart = startCellIndex;
				cellEnd = cellIndex;
			}

			for (var i = rowStart; i <= rowEnd; i++) {
				var rowCells = table.find("tr").eq(i).find("td");
				for (var j = cellStart; j <= cellEnd; j++) {
					rowCells.eq(j - 1).selectCell();
				}
			}
		}

		table.find("td").mousedown(function (e) {
			isMouseDown = true;
			var cell = $(this);

			table.find(".selected").removeClass("selected"); // deselect everything

			if (e.shiftKey) {
				selectTo(cell);
			} else {
				cell.selectCell();
				startCellIndex = cell.index();
				startRowIndex = cell.parent().index();
			}

			return false; // prevent text selection
		})
			.mouseover(function () {
				if (!isMouseDown) return;
				table.find(".selected").removeClass("selected");
				selectTo($(this));
			})
			.bind("selectstart", function () {
				return false;
			});

		$(document).mouseup(function () {
			isMouseDown = false;
		});

		// FUCK THIS

		function checkHeader($header) {

			var $cellSiblings = $header.siblings('td');
			if ($cellSiblings.length === 0) {
				return true;
			} return false;
		}

		$.fn.selectCell = function () {

			var $cell = $(this);
			$cell.addClass('selected');
			var $numberHeader = $cell.parent().children().first();
			$numberHeader.addClass('selected');
			var cellIndex = $cell.index();
			$allHeadersTop.eq(cellIndex).addClass('selected');
			return this;
		}

	};
}

// SUBMIT THE CODE ABOVE THIS LINE

if (typeof module !== 'undefined') {
	module.exports = solve;
}


