'use strict';

let http = require('http');
let fs = require('fs');

http.createServer((request, response) => {

    let method = request.method;

    if (method === 'GET') {

        response.writeHead(200, {
            'Content-Type': 'text/html'
        });

        fs.createReadStream('./public/form.html', 'UTF-8').pipe(response);

    } else if (method === 'POST') {

        let body = '';

        request.once('data', () => {

            console.log('Started colleting data');

        });

        request.on('data', (chunk) => {

            body += chunk;

        });

        request.on('end', () => {

            response.writeHead(200, {
                'Content-Type': 'text/html'
            });

            response.end(`
<!DOCTYPE html>
<html>
    <head>
        <title>Form Data</title>
    </head>
    <body>
        <h1>Your form results</h1>
        <p>${body}</p>
    </body>
</html>
`);

        });


    }




}).listen(3000);

console.log('Server is running on port 3000');
