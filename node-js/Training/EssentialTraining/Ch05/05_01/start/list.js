'use strict';

let fs = require('fs');

//let files = fs.readdirSync('./lib'); // sync with blocking request
//
//fs.readdir('./lib', (err, data) => {
//    console.log('from async ' + data);
//});


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

    let subdirs = data.filter((element) => element.indexOf('.') === -1);

    console.log(data);

}).catch((err) => {

    console.log(err);

});
