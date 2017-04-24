'use strict';

$('#load').on('click', function (event) {
    event.preventDefault();

    $.ajax({
        url: 'file.txt',
        cache: false,
        data: {
            name: 'Kalin',
            age: 42
        },
        success: onSuccess,
        error: onError
    });
});

function onSuccess(data) {
    $('#contents').html(data);
}

function onError(error) {
    console.log(error);
}
