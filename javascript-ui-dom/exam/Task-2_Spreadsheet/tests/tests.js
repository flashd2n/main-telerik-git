const {expect} = require('chai');

const {jsdom} = require('jsdom'),
	document = jsdom('<html></html>', {}),
	window = document.defaultView;
const $ = require('jquery')(window);

global.document = document;
global.window = window;
global.$ = $;

const solve = require('../task/task');

describe('Test', () => {
	let result;

	beforeEach(() => result = solve());

	describe('Zero tests', () => {
		it('Expect correct table structure', () => {
			document.body.innerHTML = '<div id="root"></div>';

			const rows = 3, cols = 5;
			result('#root', rows, cols);

			const $root = $('#root');
			const $table = $root.find('.spreadsheet-table');

			expect($table).to.have.length(1);

			const $cells = $table.find('.spreadsheet-item');
			expect($cells).to.have.length((rows + 1) * (cols + 1));

			const cellMatrix = [];
			(function() {
				const cellArray = Array.from($cells);

				for(let i = 0; i <= rows; i += 1) {
					const row = cellArray.slice(i * (cols + 1), (i + 1) * (cols + 1)).map($);
					cellMatrix.push(row);
				}
			}()); // build 2d array of jquery elements

			expect(cellMatrix[0][0].hasClass('spreadsheet-header')).to.be.true;
			expect(cellMatrix[0][0].hasClass('spreadsheet-cell')).to.be.false;
			expect(cellMatrix[0][0].html()).to.equal('');

			(function() {
				const LETTERS = "@ABCDE"; // offset with @ on purpose
				for(let j = 1; j <= cols; j += 1) {
					expect(cellMatrix[0][j].hasClass('spreadsheet-header')).to.be.true;
					expect(cellMatrix[0][j].hasClass('spreadsheet-cell')).to.be.false;
					expect(cellMatrix[0][j].html()).to.equal(LETTERS[j]);
				}
			}());

			for(let i = 1; i <= rows; i += 1) {
				expect(cellMatrix[i][0].hasClass('spreadsheet-header')).to.be.true;
				expect(cellMatrix[i][0].hasClass('spreadsheet-cell')).to.be.false;
				expect(cellMatrix[i][0].html()).to.equal(i + '');

				for(let j = 1; j <= cols; j += 1) {
					expect(cellMatrix[i][j].hasClass('spreadsheet-header')).to.be.false;
					expect(cellMatrix[i][j].hasClass('spreadsheet-cell')).to.be.true;
					const $span = cellMatrix[i][j].find('span');
					const $input = cellMatrix[i][j].find('input');

					expect($span).to.have.length(1);
					expect($span.html()).to.equal('');
					expect($input).to.have.length(1);
				}
			}
		});
	});
});
