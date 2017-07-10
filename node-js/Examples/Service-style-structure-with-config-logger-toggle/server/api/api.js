'use strict';

var router = require('express').Router();
const categoryRouter = require('./category/categoryRoutes');
const postRouter = require('./post/postRoutes');
const userRouter = require('./user/userRoutes');


router.use('/users', userRouter);
router.use('/categories', categoryRouter);
router.use('/posts', postRouter);

module.exports = router;
