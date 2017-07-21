/* globals __dirname */

const express = require('express');
const bodyParser = require('body-parser');
const cookieParser = require('cookie-parser');
const session = require('express-session');
const path = require('path');
const controller = require('./controllers/all.controller');

const init = (data) => {
    const app = express();

    app.set('view engine', 'pug');
    app.use(bodyParser.json());
    app.use(bodyParser.urlencoded({ extended: true }));

    app.use(cookieParser());
    app.use(session({ secret: 'Purple Unicorn', cookie: { maxAge: 60000 } }));

    app.use(require('connect-flash')());
    app.use((req, res, next) => {
        res.locals.messages = require('express-messages')(req, res);
        next();
    });

    app.use('/libs', express.static(path.join(__dirname, '../node_modules/')));

    app.get('/', (req, res) => {
        return res.render('home');
    });

    app.get('/items', (req, res) => {
        controller.getItems(req, res, data);
    });

    app.post('/items', controller.validation, (req, res) => {
        controller.submitItem(req, res, data);
    });

    app.get('/form', (req, res) => {
        res.render('items/form');
    });

    return Promise.resolve(app); // good idea in order unify all init operations
        // (db connection, data init, app init and so on) to work with promises
};

module.exports = {
    init,
};
