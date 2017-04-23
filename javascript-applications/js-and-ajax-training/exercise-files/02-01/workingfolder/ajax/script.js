

var request;

if (window.XMLHttpRequest) {
	request = new XMLHttpRequest();
} else {
	request = new ActiveXObject("Microsoft.XMLHTTP");
}

request.open('GET', 'data.txt');

request.onreadystatechange = function() {
	if ((request.readyState===4) && (request.status===200)) {
		
		let modify = document.getElementById('update');
		modify.innerHTML = request.responseText;

		console.log(modify);


	}
}

request.send();
