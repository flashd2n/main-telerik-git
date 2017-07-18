const { Router } = require('express');
const items = [{ name: 'Kalin', age: 28 }];
const router = new Router();

const attach = (app) => {
    router.route('/')
        .get((req, res) => {
            res.send(items);
        })
        .post((req, res) => {
            const body = req.body;
            console.log(body);
            res.send(true);
        });
    router.route('/:name')
        .get((req, res) => {
            const name = req.params.name;
            const returnItem = items.find((item) => item.name === name);

            if (!returnItem) {
                return res.redirect('/404');
            }

            return res.send(returnItem);
        });

    app.use('/api/items', router);
};

module.exports = attach;
