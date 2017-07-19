const { connectToDb } = require('./app/data');
const setupApp = require('./app');
const dbUrl = 'mongodb://localhost/lecture-auth-sessions';

connectToDb(dbUrl)
    .then((db) => {
        return setupApp(db);
    })
    .then((app) => {
        app.listen(3001, () => {
            console.log('Server running on port 3001');
        });
    })
    .catch((err) => {
        console.log(err.message);
    });
