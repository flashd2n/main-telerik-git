/* globals __dirname */

const express = require('express');
const bodyParser = require('body-parser');
const morgan = require('morgan');
const path = require('path');

const configApp = (app) => {
    app.use(morgan('dev'));
    app.use(bodyParser.json());
    app.use(bodyParser.urlencoded({ extended: true }));
    app.use('/libs', express.static(path.join(__dirname, '../../node_modules')));
    app.use('/public', express.static(path.join(__dirname, '../../public')));
    app.set('views', path.join(__dirname, '../views'));
    app.set('view engine', 'pug');
};

module.exports = configApp;
