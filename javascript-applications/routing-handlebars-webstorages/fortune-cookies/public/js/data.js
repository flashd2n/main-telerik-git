'use strict';

import requester from 'requester';


function getUsers() {
    return requester.get('api/users');
}

function getCookies() {
    return requester.get('api/cookies');
}

function login(username, passHash) {

    const body = {
        username,
        passHash
    };

    return requester.put('api/auth', body);
}

function register(username, passHash) {
    const body = {
        username,
        passHash
    };

    return requester.post('api/users', body);
}

export {
    getUsers,
    getCookies,
    login,
    register
};
