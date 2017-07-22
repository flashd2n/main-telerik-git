const { MongoClient, ObjectID } = require('mongodb');

const connectionString = 'mongodb://localhost/project-structure-training';

MongoClient.connect(connectionString)
    .then((db) => {
        const collection = db.collection('todos');

        const filter = {
            users: {
                $elemMatch: {
                    $in: ['Cuki'],
                },
            },
        };

        return collection.find(filter).toArray();
    })
    .then((data) => {
        console.log(data);
    })
    .catch((err) => {
        console.log(err);
    });

// ---------------- FIND ---------------------
        // const filter = {
        //     isDone: true,
        // };

        // const filter = {
        //     $or: [ // ---> WORKS WITH $OR AND $AND
        //         {
        //             isDone: true,
        //         },
        //         {
        //             text: {
        //                 $regex: '.*1.*',
        //             },
        //         },
        //     ],
        // };

        // const selection = { // TAKE ONLY THE TEXT PROPERTY
        //     text: 1,
        //     _id: 0,
        // };

        // const page = 2;
        // const size = 3;

        // const skip = (page - 1) * 3; // need to calculate this, because 'skip argument' skips N number of entries, but I am interested in blocks (pages) of entries

        // return collection.find(filter, selection, skip, size).toArray();

        // return collection.findOne({ ---> MUST use ObjectID to query the DB by _id, because _id is not a string, but a mongo object
        //     _id: new ObjectID('597244ce5da1112af80c79b0'),
        // });

        // return collection.find({ ---> using REGEX to filter data by value
        //     text: {
        //         $regex: 'testing.*',
        //     },
        // }).toArray();

//----- NESTED

// users is an array proeprty of the entries 

// const filter = {
//             users: {
//                 $elemMatch: {
//                     $in: ['Cuki'],
//                 },
//             },
//         };

// ------------------- DELETE -------------------------
//  const filter = {
//             isDone: true,
//         };

//         return collection.deleteMany(filter); // all items are deleted
//         // return collection.deleteOne(filter); // first found item is deleted

// ------------------- UPDATE --------------------------

// -------- BY EDITING THE PROPERTIES OF AN ENTRY

// const filter = {
//             _id: new ObjectID('59735d5ca1eb2b14384c92e3'),
//         };

//         // const update = {
//         //     $set: {
//         //         isDone: true,
//         //         isAddedFromCode: [],
//         //     },
//         // };

//         const update = {
//             $addToSet: {
//                 isAddedFromCode: 'coode',
//             },
//         };

//         return collection.updateOne(filter, update);

// -------- BY REPLACING THE ENTRY

// const { MongoClient, ObjectID } = require('mongodb');

// const connectionString = 'mongodb://localhost/project-structure-training';

// const filter = {
//     _id: new ObjectID('59735d5ca1eb2b14384c92e5'),
// };

// let collection = null;

// MongoClient.connect(connectionString)
//     .then((db) => {
//         collection = db.collection('todos');

//         return collection.findOne(filter);
//     })
//     .then((item) => {
//         item.isDone = true;

//         return collection.updateOne(filter, item);
//     })
//     .then((data) => {
//         console.log(data);
//     })
//     .catch((err) => {
//         console.log(err);
//     });