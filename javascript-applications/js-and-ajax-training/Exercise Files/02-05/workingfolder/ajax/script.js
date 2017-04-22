'use strict'




function loadAJAX() {
	var request;

	if (window.XMLHttpRequest) {
		request = new XMLHttpRequest();
	} else {
		request = new ActiveXObject("Microsoft.XMLHTTP");
	}


	request.open('GET', 'data.json');


	request.onreadystatechange = function () {

		if ((request.readyState === 4) && (request.status === 200)) {



		}
	}

	request.send();
}