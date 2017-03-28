const {expect} = require('chai');

const {jsdom} = require('jsdom');

global.document = jsdom('<html></html>', {});
global.window = document.defaultView;

const solve = require('../task/task');

describe('Test', () => {
	let result;

	beforeEach(() => result = solve());

	describe('Zero tests', () => {
		it('Expect correct structure when no default values are provided', () => {
			document.body.innerHTML = '<div id="root"></div>';
			const root = document.querySelector('#root');

			result('#root');

			let elements = Array.from(root.children);
			expect(elements).to.have.length(3);
			expect(elements[0].className).to.equal('column-container');
			expect(elements[1].tagName).to.equal('INPUT');
			expect(elements[2].tagName).to.equal('BUTTON');

			const radios = elements[0].querySelectorAll('input[type=radio]');
			expect(radios).to.have.length(2);
			expect(radios[0].name).to.equal(radios[1].name);

			elements = Array.from(elements[0].children);

			expect(elements).to.have.length(2);
			expect(elements[0].className).to.equal('column');
			expect(elements[1].className).to.equal('column');

			elements.forEach(column => {
				const elements = Array.from(column.children);
				expect(elements).to.have.length(2);
				expect(elements[0].className).to.equal('select');
				expect(elements[1].innerHTML).to.equal('');

				const radio = elements[0].querySelector('input');
				expect(radio.type).to.equal('radio');
			});
		});

		it('Expect correct structure when default values are provided', () => {
			document.body.innerHTML = '<div id="root"></div>';
			const root = document.querySelector('#root');

			const columns = [
				[ 'Banana', 'Apple', 'Cactus' ],
				[ 'Cabbage', 'Cucumber' ]
			];
			result('#root', ...columns);

			let elements = Array.from(root.children);
			expect(elements).to.have.length(3);
			expect(elements[0].className).to.equal('column-container');
			expect(elements[1].tagName).to.equal('INPUT');
			expect(elements[2].tagName).to.equal('BUTTON');

			const radios = elements[0].querySelectorAll('input[type=radio]');
			expect(radios).to.have.length(2);
			expect(radios[0].name).to.equal(radios[1].name);

			elements = Array.from(elements[0].children);

			expect(elements).to.have.length(2);
			expect(elements[0].className).to.equal('column');
			expect(elements[1].className).to.equal('column');

			elements.forEach((column, i) => {
				const elements = Array.from(column.children);
				expect(elements).to.have.length(2);
				expect(elements[0].className).to.equal('select');

				const radio = elements[0].querySelector('input');
				expect(radio.type).to.equal('radio');

				const lis = Array.from(elements[1].querySelectorAll('li'));
				expect(lis.length).to.equal(columns[i].length);
				
				lis.forEach((li, j) => {
					expect(li.querySelector('img').className).to.equal('delete');
					expect(li.innerHTML.replace(/<.*>/g, '').trim()).to.equal(columns[i][j]);
				});
			});
		});
	});
});
