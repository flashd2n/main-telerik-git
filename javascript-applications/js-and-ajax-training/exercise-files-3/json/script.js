'use strict';

$.ajax({
    url: 'data.json',
    success: function (data) {
        console.log(data);
    }
});
