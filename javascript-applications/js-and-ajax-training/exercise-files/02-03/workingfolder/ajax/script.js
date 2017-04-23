'use strict';

var request;

if (window.XMLHttpRequest) {
	request = new XMLHttpRequest();
} else {
	request = new ActiveXObject("Microsoft.XMLHTTP");
}

request.open('GET', 'data.xml');

request.onreadystatechange = function() {

	if ((request.readyState===4) && (request.status===200)) {

		let dataXML = request.responseXML;
		
		let list = document.createElement('ul');
		let allNames = dataXML.getElementsByTagName('name');

		for(let i = 0; i < allNames.length; i++){

			let item = document.createElement('li');
			item.innerHTML = allNames[i].innerHTML;
			list.appendChild(item);

		}

		document.body.appendChild(list);
}

}
request.send();
