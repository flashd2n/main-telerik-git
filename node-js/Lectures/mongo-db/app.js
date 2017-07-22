const { MongoClient, ObjectID } = require('mongodb');

const connectionString = 'mongodb://localhost/project-structure-training';

MongoClient.connect(connectionString)
    .then((db) => {
        const collection = db.collection('items');

        return collection.findOne({
            _id: new ObjectID('597244ce5da1112af80c79b0'),
        });

        // return collection.find({
        //     text: {
        //         $regex: 'testing.*',
        //     },
        // }).toArray();
    })
    .then((data) => {
        console.log(data);
    })
    .catch((err) => {
        console.log(err);
    });
