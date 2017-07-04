'use strict';

let MongoClient = require('mongodb').MongoClient;

let url = 'mongodb://localhost:27017/learning_mongo';

let searchQuery = {
    'tourName': 'Big Sur Retreat'
};

let dbCollection = 'tours';


const findDocuments = (dbCollection, searchQuery, db) => {

    let collection = db.collection(dbCollection);

    return new Promise((resolve, reject) => {

        collection.find(searchQuery).toArray((err, docs) => {

            if (err) {
                reject(err);
            } else {
                resolve(docs);
            }
        });
    });
};

//MongoClient.connect(url, (err, db) => {
//
//    if (err) {
//        console.log(err);
//    } else {
//        findDocuments(dbCollection, searchQuery, db).then((docs) => {
//
//            console.log(docs);
//
//        }).then(() => {
//            db.close();
//        }).catch((err) => {
//
//            console.log(err);
//
//        });//    }
//
//});

const ConnectToDb = (url) => {

    return new Promise((resolve, reject) => {

        MongoClient.connect(url).then((db) => {

            resolve(db);

        }).catch((err) => {

            reject(err);

        });
    });
};

let stupid;

ConnectToDb(url).then((db) => {

    stupid = db;

    return findDocuments(dbCollection, searchQuery, db);

}).then((docs) => {

    console.log(docs);

}).then(() => {

    stupid.close();

}).catch((err) => {
    console.log(err);
});
