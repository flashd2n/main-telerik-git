const { MongoClient, ObjectID } = require('mongodb');

const connectionString = 'mongodb://localhost/project-structure-training';

const users = ['Gosho', 'Pesho', 'Stamat', 'Cuki', 'Penka', 'Pepi', 'Mimi', 'Lili'];

MongoClient.connect(connectionString)
    .then((db) => {
        const collection = db.collection('todos');

        collection.drop(); // drop the collection in order to recreate it -> this way it will always have a fresh set of the defined entries

        const todos = Array.from({ length: 15 })
            .map((_, index) => {
                return {
                    text: 'Todo #' + index,
                    isDone: !!(index % 2),
                    users: Array.from({ length: 3 })
                        .map((__, index2) => {
                            return users[(index + index2) % users.length];
                        }),
                };
            });
        return collection.insertMany(todos);
    })
    .then((data) => {
        console.log('result -->', data.result); // some useless info
        console.log('ops -->', data.ops); // Array of all inserted objects + their _ids
        console.log('count -->', data.insertedCount); // number of inserted entries
        console.log('ids -->', data.insertedIds); // an array of ObjectIDs of the inserted elements
    })
    .catch((err) => {
        console.log(err);
    });
