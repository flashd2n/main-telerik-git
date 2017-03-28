'use strict';

function solve() {

	return function (selector, defaultLeft, defaultRight) {

		var leftContents = defaultLeft || [];
		var rightContents = defaultRight || [];
		var mainContainer = document.querySelector(selector);

		var columnsContainer = document.createElement('div');
		columnsContainer.className = 'column-container';

		// build left column

		var leftColumn = buildColumn(leftContents, 'left');

		// build right column

		var rightColumn = buildColumn(rightContents, 'right');

		columnsContainer.appendChild(leftColumn);
		columnsContainer.appendChild(rightColumn);
		mainContainer.appendChild(columnsContainer);

		// build input field

		var input = document.createElement('input');
		input.setAttribute('size', '40');
		input.setAttribute('autofocus', '');

		mainContainer.appendChild(input);

		// build button

		var button = document.createElement('button');
		button.innerHTML = 'Add';

		mainContainer.appendChild(button);

		// implement functionality

		// removing

		columnsContainer.addEventListener('click', function (event) {
			event.stopPropagation();

			var target = event.target;

			if (target.className === 'delete') {

				var entryToDelete = target.parentNode;
				var textToDisplay = target.nextSibling.nodeValue;

				input.value = textToDisplay;

				entryToDelete.parentNode.removeChild(entryToDelete);
			}
		}, false);

		// adding

		button.addEventListener('click', function (event) {

			var textToAdd = input.value;
			textToAdd = textToAdd.trim();

			if (textToAdd !== '') {

				var columnToAdd = checkRadioButtons();

				var foundColumn;
				var listToAppendNewItem;

				if (columnToAdd === 'left') {

					foundColumn = columnsContainer.firstElementChild;
					listToAppendNewItem = foundColumn.children[1];

					var newEntry = createEntry(textToAdd);

					listToAppendNewItem.appendChild(newEntry);

					input.value = '';

				} else {

					foundColumn = columnsContainer.lastElementChild;
					listToAppendNewItem = foundColumn.children[1];

					var newEntry = createEntry(textToAdd);

					listToAppendNewItem.appendChild(newEntry);
					
					input.value = '';
				}
			}
		}, false);
	};

	function buildColumn(content, side) {

		var column = document.createElement('div');
		column.className = 'column';

		var selectButtonContainer = document.createElement('div');
		selectButtonContainer.className = 'select';

		var selectButton = document.createElement('input');
		selectButton.setAttribute('type', 'radio');
		selectButton.setAttribute('name', 'column-select');
		selectButton.setAttribute('id', side + '-select-button');

		if (side === 'left') {
			selectButton.checked = true;
		}

		var selectLabel = document.createElement('label');
		selectLabel.setAttribute('for', side + '-select-button');
		selectLabel.innerHTML = 'Add here';

		selectButtonContainer.appendChild(selectButton);
		selectButtonContainer.appendChild(selectLabel);
		column.appendChild(selectButtonContainer);

		var listOfElements = document.createElement('ol');

		// create entries and append;

		content.forEach(function (entry) {

			var element = createEntry(entry);

			listOfElements.appendChild(element);

		});

		column.appendChild(listOfElements);
		return column;
	}

	function createEntry(content) {

		var deleteIcon = document.createElement('img');
		deleteIcon.className = 'delete';
		deleteIcon.setAttribute('src', 'imgs/Remove-icon.png');

		var listContent = document.createTextNode(content);

		var listElement = document.createElement('li');
		listElement.className = 'entry';
		listElement.appendChild(deleteIcon);
		listElement.appendChild(listContent);

		return listElement;

	}

	function checkRadioButtons() {
		var leftRadio = document.getElementById('left-select-button');
		var rightRadio = document.getElementById('left-select-button');
		if (leftRadio.checked) {
			return 'left';
		}
		return 'right';
	}
}

// SUBMIT THE CODE ABOVE THIS LINE

if (typeof module !== 'undefined') {
	module.exports = solve;
}
