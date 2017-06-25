'use strict';

const wsc = new WebSocket('ws://localhost:3000');

wsc.onopen = () => {
    setTitle('Connected to cyber chat!');
};

wsc.onclose = () => {
    setTitle('Disconnected');
};

wsc.onmessage = (msg) => {

    printMessage(msg.data);

};


document.forms[0].onsubmit = function () {
    var input = document.getElementById('message');

    wsc.send(input.value);

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
