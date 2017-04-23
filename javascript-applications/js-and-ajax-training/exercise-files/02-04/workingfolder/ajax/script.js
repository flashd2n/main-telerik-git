'use strict'

var request;

if (window.XMLHttpRequest) {
	request = new XMLHttpRequest();
} else {
	request = new ActiveXObject("Microsoft.XMLHTTP");
}

request.open('GET', 'data.json');

request.onreadystatechange = function() {

	if ((request.readyState===4) && (request.status===200)) {

		let data = JSON.parse(request.responseText);

		let list = document.createElement('ul');

		for(let i = 0; i < data.length; i++){

			let item = document.createElement('li');
			item.innerHTML = data[i].name;
			list.appendChild(item);

		}

		document.getElementById('update').appendChild(list);

	}
}

request.send();
