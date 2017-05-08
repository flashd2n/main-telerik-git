'use strict';

import router from 'myRouter';

import {
    homeController
} from 'homeController';

import {
    myCookieController
} from 'myCookieController';

import userController from 'userController';

// build router routes

router.on('', () => location.hash = '#/home')
    .on('/', () => location.hash = '#/home')
    .on('/home', homeController)
    .on('/home/:category', homeController)
    .on('/my-cookie', myCookieController)
    .on('/auth', userController.auth)
    .on('/logout', userController.logout)
    .on('/login', userController.login)
    .on('/register', userController.register);


// set up window on events


$(window).on('load', router.navigate.bind(router));
$(window).on('hashchange', router.navigate.bind(router));
