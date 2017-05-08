'use strict';

const appContainer = $('#app-container');

class MyRouter {
    constructor() {
        this._routes = [];
    }

    on(patternUrl, callback) {
        this._routes.push({
            patternUrl,
            callback
        });

        return this;
    }

    navigate() {

        const currentUrl = location.hash.slice(1);

        for (let route of this._routes) {

            const parameters = this.matchUrls(currentUrl, route.patternUrl);

            if (parameters) {

                route.callback(parameters);

                return;
            }

        }

    }

    matchUrls(currentUrl, patternUrl) {

        const currentUrlParts = currentUrl.split('/');
        const patternUrlParts = patternUrl.split('/');

        if (currentUrlParts.length !== patternUrlParts.length) {
            return false;
        }

        const parameters = {};

        const len = currentUrlParts.length;

        for (let i = 0; i < len; i++) {

            if (patternUrlParts[i][0] !== ':') {

                if (patternUrlParts[i] !== currentUrlParts[i]) {
                    return false;
                }

            } else {

                const paramName = patternUrlParts[i].slice(1);
                parameters[paramName] = currentUrlParts[i];

            }

        }

        return parameters;

    }
}

const router = new MyRouter();

router.on('/home', () => appContainer.html('Home Page'))
    .on('/user', () => appContainer.html('Showing users'))
    .on('/user/:id', (parameters) => appContainer.html(`Showing user with id: ${parameters.id}`));

$(window).on('load', router.navigate.bind(router));
$(window).on('hashchange', router.navigate.bind(router));
