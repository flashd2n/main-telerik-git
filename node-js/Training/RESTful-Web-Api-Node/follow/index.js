'use strict';

const express = require('express');
const app = express();

app.get('/', (req, res) => {
    res.send('ho ho ho');
});

app.listen(8080, () => {
    console.log('Server is running on port 8080');
});
