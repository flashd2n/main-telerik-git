const database = [{
    id: '1',
    username: 'flash',
    password: '1234',
}];

const users = {
    findByUsername(username) {
        username = username.toLocaleLowerCase();
        const user = database
            .find((x) => x.username.toLocaleLowerCase() === username);
        return new Promise((resolve, reject) => {
            if (user) {
                resolve(user);
            } else {
                reject('No such user');
            }
        });
    },
    findById(id) {
        const user = database
            .find((x) => x.id === id);
        return new Promise((resolve, reject) => {
            if (user) {
                resolve(user);
            } else {
                reject(new Error('No such user'));
            }
        });
    },
};

module.exports = { users };
