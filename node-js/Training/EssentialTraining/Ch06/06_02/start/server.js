'use strict';

let http = require('http');

let server = http.createServer((request, responce) => {

    responce.writeHead(200, {
        'Content-Type': 'text/html'
    });

    responce.end(`

<!DOCTYPE html>
<html>
    <head>
        <title>HTML Response</title>
    </head>
    <body>
        <h1>Serving HTML</h1>
        <p>${request.url}</p>
        <p>${request.method}</p>
    </body>
</html>

`);

});

server.listen(3000);

console.log('Server listening on port 3000');
