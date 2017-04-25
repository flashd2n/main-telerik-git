'use strict';

$.ajax({
    url: 'data.json',
    dataType: 'json',
    success: function (data) {
        $('#count').html(`Your search returned ${data.count} results`);
    }
});
