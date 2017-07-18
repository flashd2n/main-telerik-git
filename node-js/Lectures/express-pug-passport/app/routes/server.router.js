const items = [{
    id: 1,
    name: 'Cuki',
},
{
    id: 2,
    name: 'flash',
}];

const attach = (app) => {
    app.get('/', (req, res) => {
        res.render('all', {
            model: items,
        });
    });

    app.get('/:id', (req, res) => {
        const id = parseInt(req.params.id, 10);
        const item = items.find((i) => i.id === id);

        if (item) {
            return res.render('details', {
                model: item,
            });
        }
        return res.status(404).redirect('/404');
    });
};

module.exports = attach;
