'use strict'

$(function () {

    $.getJSON('data.json', function (info) {
        var output = '';
        for (var i = 0; i <= info.links.length - 1; i++) {
            for (let key in info.links[i]) {
                if (info.links[i].hasOwnProperty(key)) {
                    output += '<li>' +
                        '<a href = "' + info.links[i][key] +
                        '">' + key + '</a>';
                    '</li>';
                }
            }
        }

        var update = document.getElementById('links');
        update.innerHTML = output;
    });
});
