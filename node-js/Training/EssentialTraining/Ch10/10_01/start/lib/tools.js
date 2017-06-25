'use strict';

const http = require('https');

const printName = (person) => {

    return `${person.last} ${person.first}`;

};

const loadWiki = (person, callback) => {

    const firstName = person.first;
    const lastName = person.last;
    let html = '';

    http.get(`https://en.wikipedia.org/wiki/${firstName}_${lastName}`, (response) => {

        response.setEncoding('UTF-8');

        response.on('data', (chunk) => {

            html += chunk;

        });

        response.on('end', () => {

            callback(html);

        });

    });

};


module.exports = {
    printName,
    loadWiki
};
