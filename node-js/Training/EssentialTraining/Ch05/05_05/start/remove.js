let fs = require('fs');

fs.unlinkSync('./lib/config.json');

fs.unlink('notes.md', (err) => {
   
    if(err){
       console.log(err);
    } else{
        console.log('notes.ms file deleted');
    }
    
});