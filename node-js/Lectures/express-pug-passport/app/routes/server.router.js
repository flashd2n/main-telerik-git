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
};

module.exports = attach;
