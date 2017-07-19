const { MongoClient } = require('mongodb');

const connectToDb = (url) => {
    return new Promise((resolve, reject) => {
        MongoClient.connect(url).then((db) => {
            resolve(db);
        }).catch((err) => {
            reject(err);
        });
    });
};

module.exports = connectToDb;
