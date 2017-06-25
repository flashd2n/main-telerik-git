'use strict';

const socket = io('http://localhost:3000');

socket.on('disconnect', () => {

    setTitle('Disconnected');

});

socket.on('connect', () => {

    setTitle('Connected');

});

socket.on('message', (msg) => {

    printMessage(msg);

});


document.forms[0].onsubmit = function () {
    var input = document.getElementById('message');
    printMessage(input.value);

    socket.emit('chat', input.value);

    input.value = '';
};

function setTitle(title) {
    document.querySelector('h1').innerHTML = title;
}

function printMessage(message) {
    var p = document.createElement('p');
    p.innerText = message;
    document.querySelector('div.messages').appendChild(p);
}
