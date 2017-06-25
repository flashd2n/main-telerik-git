'use strict';

let http = require('http');
let fs = require('fs');
let path = require('path');

http.createServer((request, response) => {

    console.log(`Incoming request type ${request.method} for url ${request.url}`);

    if (request.url === '/') {

        //        fs.readFile('./public/index.html', 'UTF-8', (err, html) => {
        //
        //            if (err) {
        //
        //                response.writeHead(404, {
        //                    'Content-Type': 'text/plain'
        //                });
        //                response.end('404 Problem Accessing The File');
        //
        //            } else {
        //
        //                response.writeHead(200, {
        //                    'Content-Type': 'text/html'
        //                });
        //                response.end(html);
        //
        //            }
        //        });

        response.writeHead(200, {
            'Content-Type': 'text/html'
        });

        let test = fs.createReadStream('./public/index.html', 'UTF-8');

        test.pipe(response);

    } else if (request.url.match(/.css$/)) {

        let pathToStyle = path.join(__dirname, 'public', request.url);

        let styleStream = fs.createReadStream(pathToStyle, 'UTF-8');

        response.writeHead(200, {
            'Content-Type': 'text/css'
        });

        styleStream.pipe(response);


    } else if (request.url.match(/.jpg$/)) {


        let pathToImage = path.join(__dirname, 'public', request.url);

        let imageStream = fs.createReadStream(pathToImage);

        response.writeHead(200, {
            'Content-Type': 'image/jpeg'
        });

        imageStream.pipe(response);

    } else {
        response.writeHead(404, {
            'Content-Type': 'text/plain'
        });
        response.end('404 File Not Found');
    }


}).listen(3001);
