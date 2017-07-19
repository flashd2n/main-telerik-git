const { Router } = require('express');
const passport = require('passport');
const router = new Router();

const attach = (app) => {
    router.route('/sign-in')
        .get((req, res) => {
            res.render('form');
        })
        .post(passport.authenticate('local', {
            successRedirect: '/',
            failureRedirect: '/auth/sign-in',
            failureFlash: true,
        }));

    router.route('/logout')
        .get((req, res) => {
            req.logout();
            res.redirect('/');
        });

    app.use('/auth', router);
};

module.exports = attach;
