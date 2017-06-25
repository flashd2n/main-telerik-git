'use strict';

const express = require('express');
const cors = require('cors');
const bodyParser = require('body-parser');
const data = require('./database/skierTerms');
const fs = require('fs');
const app = express();

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
    extended: false
}));

app.use((request, response, next) => {

    const method = request.method;
    const route = request.url;
    const body = JSON.stringify(request.body);


    console.log(`${method} request for ${route} with data: ${body}`);

    next();

});

app.use(express.static('./public'));

// API

app.use(cors());

app.get('/dictionary-api', (request, response) => {

    //    response.json(data);

    let stream = fs.createReadStream('./database/skierTerms.json', 'UTF-8');
    stream.pipe(response);

});

app.post('/dictionary-api', (request, response) => {

    data.push(request.body);
    response.json(data);

});

app.delete('./dictionary-api/:term', (request, response) => {

    let toDelete = request.params.term;
    // filter the array
    // respond with the json data

});

app.listen(3000);

console.log('Express is running on port 3000');

module.exports = app;
