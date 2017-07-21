const { MongoClient } = require('mongodb');

const init = (url) => {
    return MongoClient.connect(url);
};

module.exports = {
    init,
};
