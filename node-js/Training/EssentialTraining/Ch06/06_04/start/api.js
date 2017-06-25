'use strict';

let http = require('http');
let data = require('./data/inventory');

http.createServer((request, response) => {

    let url = request.url;

    if (url === '/') {

        response.writeHead(200, {
            'Content-Type': 'application/json'
        });

        response.end(JSON.stringify(GetAllItems()));


    } else if (url === '/onstock') {

        response.writeHead(200, {
            'Content-Type': 'application/json'
        });

        response.end(JSON.stringify(GetAllOnStockItems()));

    } else if (url === '/onbackorder') {

        response.writeHead(200, {
            'Content-Type': 'application/json'
        });

        response.end(JSON.stringify(GetAllBackOrderItems()));

    } else {

        response.writeHead(404, {
            'Content-Type': 'text/plain'
        });

        response.end('File not found');

    }


}).listen(3000);

console.log('Server is running at post 3000');

const GetAllItems = () => {

    return JSON.stringify(data);

};

const GetAllOnStockItems = () => {

    return data.filter(x => x.avail === 'In stock');

};

const GetAllBackOrderItems = () => {

    return data.filter(x => x.avail === 'On back order');

};
