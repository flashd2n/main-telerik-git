'use strict';
const fs = require('fs');
const path = require('path');
const express = require('express');
const http = require('http');
const app = express();
const server = http.createServer(app).listen(3000);
const io = require('socket.io')(server);


app.get('/', (req, res) => {
    res.send('HOMEE');
});

app.use(express.static('./public'));

app.get('/chat', (req, res) => {
    const pathToFile = path.join(__dirname, '/public/chat.html');
    const stream = fs.createReadStream(pathToFile, 'UTF-8');
    stream.pipe(res);
});

io.on('connection', (client) => {

    console.log('connected client');

    client.on('chat', (msg) => {

        client.broadcast.emit('message', msg);

    });


    client.emit('message', 'welcome!');

});

console.log('Socket App running on port 3000');
