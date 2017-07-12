'use strict';

var router = require('express').Router();
var logger = require('../../util/logger');
var controller = require('./categoryController');
var auth = require('../../auth/auth');

// lock down the right routes :)
router.param('id', controller.params);

router.route('/')
    .get(controller.get)
    .post([auth.decodeToken(), auth.getFreshUser()], controller.post);

router.route('/:id')
    .get(controller.getOne)
    .put([auth.decodeToken(), auth.getFreshUser()], controller.put)
    .delete([auth.decodeToken(), auth.getFreshUser()], controller.delete);

module.exports = router;
