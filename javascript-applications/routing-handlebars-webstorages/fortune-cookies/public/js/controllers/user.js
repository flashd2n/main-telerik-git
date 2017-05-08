'use strict';

import {
    loadTemplate
} from 'templates';

import requester from 'requester';

import {
    login,
    register
} from 'data';

const LOCALSTORAGE_AUTH_KEY_NAME = 'authkey';
const AUTH_KEY_HEADER = 'x-auth-key';

class userController {

    auth() {

        const $appContainer = $('#app-container');

        loadTemplate('auth').then(function (renderer) {

            const template = renderer();
            $appContainer.html(template);

        });
    }

    login() {

        const logInusername = $('#input-username').val();
        const logInpassword = $('#input-password').val();
        const logInpassHash = logInpassword;

        userController.executeLogin(logInusername, logInpassHash);

    }

    register() {

        const regUsername = $('#input-username').val();
        const regPassword = $('#input-password').val();
        const regPassHash = regPassword;

        register(regUsername, regPassHash).then(function () {

            toastr.success('Registered!');
            userController.executeLogin(regUsername, regPassHash);

        }).catch(function () {
            toastr.error('Invalid username or password in Register!');
        });

    }

    logout() {

        localStorage.removeItem(LOCALSTORAGE_AUTH_KEY_NAME);

        $('#auth-btn').removeClass('hidden');
        $('#logout-btn').addClass('hidden');

        toastr.success('Logged out');

        location.hash = '#/home';

    }

    static executeLogin(username, passHash) {

        login(username, passHash).then(function (result) {

            localStorage.setItem(LOCALSTORAGE_AUTH_KEY_NAME, result.result.authKey);

            location.hash = '#/home';
            toastr.success('Logged in!');
            $('#auth-btn').addClass('hidden');
            $('#logout-btn').removeClass('hidden');

        }).catch(function () {
            toastr.error('Error when loggin in after registration');
        });

    }

}


export default new userController();
