'use strict';

import {
    getUsers,
    getCookies
} from 'data';

import {
    loadTemplate
} from 'templates';

function homeController(params) {

    const $appContainer = $('#app-container');

    Promise.all([loadTemplate('home'), getCookies()]).then(function ([renderer, cookies]) {
        console.log(renderer);
        const template = renderer(cookies);
        $appContainer.html(template);
    });


}

export {
    homeController
};
