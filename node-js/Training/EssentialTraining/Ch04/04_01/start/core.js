let path = require('path');

console.log(path.basename(__filename));

let customDir = path.join(__dirname, 'www', 'files', 'uploads');

console.log(customDir);
