'use strict';

var User = require('../api/user/userModel');
var signToken = require('./auth').signToken;

exports.signin = function (req, res, next) {

    let token = signToken(req.user._id);

    res.json({
        token: token
    });

};
