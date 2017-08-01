const validation = (req, res, next) => {
    const item = req.body;

    if (typeof item !== undefined &&
        typeof item.text === 'string' &&
        item.text.length > 3) {
        return next();
    }

    req.flash('error', 'Invalid model');

    return res.redirect('/form');
};

const getItems = (req, res, data) => {
    return data.items.getAll()
        .then((items) => {
            return res.render('items/all', { context: items });
        });
};

const submitItem = (req, res, data) => {
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
};

module.exports = {
    validation,
    getItems,
    submitItem,
};
