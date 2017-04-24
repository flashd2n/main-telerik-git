'use strict'




function loadAJAX() {
	
	let jsXHR = $.getJSON('data.json', function(data){
		console.log(data);
	});

	console.log(jsXHR);

}