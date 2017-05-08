'use strict';

import {
    getUsers,
    getCookies
} from 'data';



function myCookieController() {
    const $appContainer = $('#app-container');

    $appContainer.html('My Cookies');

}

export {
    myCookieController
};
