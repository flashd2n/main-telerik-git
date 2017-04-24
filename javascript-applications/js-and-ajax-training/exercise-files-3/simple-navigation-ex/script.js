'use strict';

// simple nav with $.ajax, apps object and callbacks

/*(function () {

    let app = {
        nav: $('nav ul li a'),
        content: $('section#main')
    };

    app.putContent = function (content) {

        this.content.html(content);

    };

    app.loadPage = function (page) {

        $.ajax({
            url: `pages/${page}.html`,
            cache: false,
            type: 'GET',
            success: function (data) {
                app.putContent(data);
            },
            error: function () {
                app.putContent('We could not find this content');
            }
        });

    };

    app.init = (function () {
        app.loadPage('home');
        app.nav.on('click', function () {

            let page = $(this).data('page');

            app.loadPage(page);

        });
    })();


})();*/



// simple nav with ajax and promises

(function () {

    let $nav = $('nav ul li a');
    requestContent('home').then(data => insertContent(data)).catch(data => insertContent(data));

    $nav.on('click', function () {

        let page = $(this).data('page');

        requestContent(page).then(data => insertContent(data)).catch(data => insertContent(data));


    });

    function requestContent(page) {

        let requestPromise = new Promise(function (resolve, reject) {

            $.ajax({
                url: `pages/${page}.html`,
                cache: false,
                type: 'GET',
                success: function (data) {
                    resolve(data);
                },
                error: function () {
                    reject('We could not find this content');
                }
            });

        });
        return requestPromise;
    }

    function insertContent(content) {

        $('section#main').html(content);

    }

})();
