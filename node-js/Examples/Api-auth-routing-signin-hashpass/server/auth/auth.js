'use strict';

var jwt = require('jsonwebtoken');
var expressJwt = require('express-jwt');
var config = require('../config/config');
var checkToken = expressJwt({
    secret: config.secrets.jwt
});
var User = require('../api/user/userModel');

exports.decodeToken = function () {
    return function (req, res, next) {

        if (req.query && req.query.hasOwnProperty('access_token')) {
            req.headers.authorization = 'Bearer ' + req.query.access_token;
        }

        // this will call next if token is valid
        // and send error if its not. It will attached
        // the decoded token to req.user
        checkToken(req, res, next);
    };
};

exports.getFreshUser = function () {
    return function (req, res, next) {

        let userId = req.user._id;

        User.findById(userId, (err, user) => {

            if (err) {
                next(err);
            } else {

                if (user) {
                    req.user = user;
                    next();
                } else {
                    next(new Error('Not user found in DB'));
                }
            }
        });

    };
};

exports.verifyUser = function () {
    return function (req, res, next) {
        var username = req.body.username;
        var password = req.body.password;

        if (!username || !password) {
            next(new Error('You must provide username and password'));
        }

        User.findOne({
            username: username
        }).then((user) => {

            if (!user) {
                next(new Error('No user found'));
            }

            if (user.authenticate(password)) {
                req.user = user;
                next();
            } else {
                next(new Error('Wrong password'));
            }

        }).catch((err) => {
            next(err);
        });

    };
};

// util method to sign tokens on signup
exports.signToken = function (id) {
    return jwt.sign({
            _id: id
        },
        config.secrets.jwt, {
            expiresInMinutes: config.expireTime
        }
    );
};
