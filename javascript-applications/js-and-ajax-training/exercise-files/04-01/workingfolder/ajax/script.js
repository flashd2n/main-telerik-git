'use strict';

$.getJSON('data.json', function(data){

    let allItems = $('<ul>').addClass('searchResults');

    $.each(data, function(key, value){
        
        let item = $('<li>');

        $('<h2>').html(value.name).appendTo(item);
        $('<img>').attr('src', `/images/${value.shortname}_tn.jpg`).appendTo(item);
        $('<p>').html(value.bio).appendTo(item);

        item.appendTo(allItems);
\
    });

    $('#update').append(allItems);

});