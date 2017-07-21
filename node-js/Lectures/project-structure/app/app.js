const express = require('express');
const bodyParser = require('body-parser');
const cookieParser = require('cookie-parser');
const session = require('express-session');
const path = require('path');

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
        return data.items.getAll()
            .then((items) => {
                console.log(items[0].id);
                return res.render('items/all', { context: items });
            });
    });

    app.post('/items', (req, res, next) => {
        const item = req.body;

        if (typeof item !== undefined &&
            typeof item.text === 'string' &&
            item.text.length > 3) {
            return next();
        }

        req.flash('error', 'Invalid model');

        return res.redirect('/form');

    }, (req, res) => {
        const item = req.body;

        data.items.create(item)
            .then((dbItem) => {
                console.log(dbItem);
                console.log(dbItem.id);
                console.log(typeof dbItem.id);
                return res.redirect('/items/' + dbItem.id);
            })
            .catch((err) => {
                res.send('Sorry bro');
            });
    });

    app.get('/form', (req, res) => {
        res.render('items/form');
    });

    return Promise.resolve(app); // good idea in order unify all init operations (db connection, data init, app init and so on) to work with promises
};

module.exports = {
    init,
};
