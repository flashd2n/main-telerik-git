'use strict'

let performActionOne = function () {

    return new Promise(function (resolve, reject) {
        resolve('action one completed');
    });

};

let performActionTwo = function () {

    return new Promise(function (resolve, reject) {
        resolve('action two completed');
    });

};

let performActionThree = function () {

    return new Promise(function (resolve, reject) {
        resolve('action three completed');
    });

};


Promise.race([performActionOne(), performActionTwo(), performActionTwo()]).then(function () {

    console.log('one of the actions has completed without caring for the rest');

});

performActionOne().then(function () {

    return performActionTwo();

}).then(function () {

    return performActionThree();

}).then(function () {

    console.log('all actions are completed with dependencies');

});

// IMPORTANT: in this case the promise.all is executed before the chained promises, even though the promises are the same

Promise.all([performActionOne(), performActionTwo(), performActionTwo()]).then(function () {

    console.log('all actions completed without dependencies');

});
