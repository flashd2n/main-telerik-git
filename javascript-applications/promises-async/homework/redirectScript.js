(function () {
    'use strict';

    let container = $('#root');

    let redirectPromise = new Promise(function (resolve, reject) {


        $('#theButton').click(function () {

            let containerPositionWidth = ($(window).width() / 2) - 250;
            let containerPositionHeight = ($(window).height() - 550) / 2;

            let overlay = $('<div>').attr('id', 'overlay').appendTo(container);

            let popup = $('<div>').attr({
                id: 'popupContainer',
                style: 'left: ' + containerPositionWidth + 'px; top: ' + containerPositionHeight + 'px;'
            }).appendTo(overlay);

            popup.append('<h2>Hey there! You are going on a trip, my friend!</h2>');

            setTimeout(function () {
                resolve();
            }, 2000);

        });

    });

    redirectPromise.then(function () {
        window.location = 'http://gomerblog.com/2017/04/top-14-united-memes/';
    });

})();
