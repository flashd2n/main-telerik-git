const express = require('express');
const app = express();

require('./middleware').baseConfig(app);

require('./routes').attach(app);

module.exports = { app };
