

var request = new XMLHttpRequest();

request.open('GET', 'data.txt');

request.onreadystatechange = function() {
	if ((request.readyState===4) && (request.status===200)) {
		console.log(request);
		document.writeln(request.responseText);
	}
}

request.send();
