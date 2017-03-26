'use strict';

function solve() {
	return function() {
		var template = [
			'first line',
			'second line',
			'...'
		].join('\n');

		return template;
	}
}

// submit the above

if(typeof module !== 'undefined') {
	module.exports = solve;
}
