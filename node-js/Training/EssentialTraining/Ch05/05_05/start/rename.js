let fs = require('fs');

fs.renameSync('./lib/project-config.js', './lib/config.json');

console.log('File Renamed');

fs.rename('./lib/notes.md', './notes.md', (err) => {
    
    if(err){
       console.log(err);
    } else {
        console.log('file moved');
    }
    
});