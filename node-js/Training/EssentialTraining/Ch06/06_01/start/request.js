'use strict';

let https = require('https');
let fs = require('fs');

let options = {
    hostname: 'en.wikipedia.org',
    path: '/wiki/George_Washington',
    method: 'GET'
};

let req = https.request(options, (response) => {

    let responseBody = '';
    console.log('Reponse from server started');
    console.log(`Server Status: ${response.statusCode}`);
    console.log(`Reponse Headers: ${response.headers}`);

    response.setEncoding('UTF-8');

    response.once('data', (chunk) => {
        console.log(chunk);
    });

    response.on('data', (chunk) => {

        console.log(`Chunk size: ${chunk.length}`);
        responseBody += chunk;
    });

    response.on('end', () => {
        fs.writeFile('george-washington.html', responseBody, (err) => {
            if (err) {
                console.log(err);
            } else {
                console.log('File downloaded');
            }
        });
    });
});


req.on('error', (err) => {
    console.log(`Requestion Error: ${err.message}`);
});

req.end();
