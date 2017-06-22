'use strict';

let fs = require('fs');
let path = require('path');

let massiveResult = [];

let readFileAsync = (path) => {

    fs.readFile(path, 'UTF-8', (err, data) => {

        massiveResult.push(data);

    });
};

const filesPromise = (directory) => {

    return new Promise((resolve, reject) => {

        fs.readdir(directory, (err, data) => {

            if (err) {
                reject(err);
            } else {
                resolve(data);
            }

        });
    });
};

filesPromise('./lib').then((data) => {

    let validFiles = data.filter(el => el.indexOf('.') !== -1);

    validFiles.forEach((file) => {

        let filePath = path.join(__dirname, 'lib', file);

        readFileAsync(filePath);

    });


}).catch((err) => {

    console.log(err);

});
