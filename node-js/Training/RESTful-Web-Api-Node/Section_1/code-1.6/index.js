var express = require('express');
var app = express();

app.get("/", function(req, res) {
	res.send("ho ho ho");
});

app.listen(8080, function() {
	console.log("Express server is running on port 8080");
});