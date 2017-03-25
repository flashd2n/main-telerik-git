'use strict';

$(function () {

    $.addTemplateFormatter('UpperCaseFormatter', function(value, option){

        return value.toUpperCase();

    });

    $('#container').loadTemplate($('#itemTemplate'), [{
        'name': 'Kalin Kostov',
        'title': 'Noob',
        'phone': '0888455003',
        'email': 'k.kostov.eu@gmail.com',
        'fulltime': true
    }, {
        'name': 'The Squirel',
        'title': 'PDancer',
        'phone': '088888888',
        'email': 'dory.pole@gmail.com',
        'fulltime': true
    }]);

    // after the data contents, you can specify options with various parameters and call back functions for before, after, on completion, paging, etc

});

// window.addEventListener('load', renderTemplate());

// function renderTemplate(){
//     $('container').loadTemplate("template.html", [{
//         'name': 'Kalin Kostov',
//         'title': 'President',
//         'phone': '0888455003',
//         'email': 'k.kostov.eu@gmail.com',
//         'fulltime': true
//     }, {
//         'name': 'Dory',
//         'title': 'Pole Dancer',
//         'phone': '088888888',
//         'email': 'dory.pole@gmail.com',
//         'fulltime': true
//     }]);
// }