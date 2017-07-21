const { BaseData } = require('./base/base.data');
const { User } = require('../models/user.model');

class UsersData extends BaseData {
    constructor(database) {
        super(database, User);
    }

    checkPassword(username, password) {
        return this.collection.findOne({
            username,
        })
        .then((user) => {
            if (user.password !== password) {
                throw new Error('Wrong password');
            }
            return true;
        })
        .catch((err) => {
            console.log(err);
        });
    }
}

module.exports = {
    UsersData,
};
