const { ItemsData } = require('./item.data');
const { UsersData } = require('./user.data');
const validator = require('../validation');

const init = (database) => {
    return Promise.resolve({
        items: new ItemsData(database, validator.validateItem),
        users: new UsersData(database),
    });
};

module.exports = {
    init,
};
