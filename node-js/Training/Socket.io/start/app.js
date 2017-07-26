const express = require('express');
const path = require('path');
const app = express();
const server = require('http').Server(app);
const io = require('socket.io')(server);
const port = 4500;

app.use(express.static(path.join(__dirname, '/public')));

io.on('connection', (socket) => {
    console.log('new connection');

    socket.emit('msg-from-server', {
        greeting: 'Hello from server!',
    });

    socket.on('msg-from-client', (msg) => {
        console.log(msg);
    });
});

server.listen(port, () => {
    console.log('server running on port 4500');
});
