'use strict'

let myPromise = new Promise(function (resolve, reject) {

    // doing something

    let isActionCompleted = false;

    if (isActionCompleted) {

        resolve('succeeded');

    } else {

        reject('failed');

    }

});


myPromise.then(function (fromResolve) {

    console.log('The action has ' + fromResolve);

}).catch(function (fromReject) {

    console.log('The action has ' + fromReject);

});
