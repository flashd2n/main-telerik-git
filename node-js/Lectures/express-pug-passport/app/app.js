const setupApp = (db) => {
    const express = require('express');
    const app = express();
    const data = require('./data');

    return new Promise((resolve, reject) => {
        require('./config').baseConfig(app);
        require('./config').authConfig(app, data, db);

        app.use((req, res, next) => {
            console.log(req.user);
            next();
        });

        app.use((req, res, next) => {
            if (req.user) {
                console.log('STILL LOGGED');
                return next();
            }
            return next();
            // next(new Error('NOT LOGGED'));
        });

        require('./routes').attach(app);
        return resolve(app);
    });
};

module.exports = setupApp;
