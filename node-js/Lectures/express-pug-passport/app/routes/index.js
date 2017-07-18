/* globals __dirname */

const fs = require('fs');
const path = require('path');

const attach = (app) => {
    fs.readdirSync(__dirname)
        .filter((results) => results.includes('router.js'))
        .map((file) => path.join(__dirname, file))
        .forEach((modulePath) => require(modulePath)(app));
};

module.exports = { attach };
