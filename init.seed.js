const url = 'mongodb://52.59.100.125:27017/etajna-sobstvenost-manager';

Promise.resolve()
    .then(() => require('./database').init(url))
    .then(async (db) => {
        console.log('Start seeding');
        await require('./utils/index').seed(db);
        console.log('Seeding completed');
        await db.close();
        return;
    });
