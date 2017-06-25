'use strict';

const express = require('express');
const http = require('http');
const app = express();
const server = http.createServer(app).listen(3000);
const io = require('socket.io')(server);

app.use(express.static('./public'));

io.on('connection', (client) => {

    console.log('connected client');

    client.on('chat', (msg) => {

        client.broadcast.emit('message', msg);

    });


    client.emit('message', 'welcome!');

});

console.log('Socket App running on port 3000');
