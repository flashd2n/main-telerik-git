const config = require('./config');

Promise.resolve()
    .then(() => {
        return require('./database').init(config.connectionString);
    })
    .then((database) => {
        return require('./data').init(database);
    })
    .then((data) => {
        return require('./app').init(data);
    })
    .then((app) => {
        app.listen(config.port, () => {
            console.log(`Server running on port ${config.port}`);
        });
    });
