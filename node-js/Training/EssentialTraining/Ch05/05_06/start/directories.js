let fs = require('fs');
let path = require('path');

//fs.renameSync('./assets/logs', './logs');
//
//console.log('directory moved');

//fs.rmdir('./assets', (err) => {
//   
//    if(err){
//        console.log(err);
//    } else {
//        console.log('Directory removed');
//    }
//    
//});

let deleteAllFiles = new Promise((resolve, reject) =>{
   
    fs.readdir('./logs', (err, data) => {
        
        data.forEach((file) => {

            let pathToFile = path.join(__dirname, 'logs', file);

            fs.unlinkSync(pathToFile);

        });
        
        resolve();
        
    });
    
});

deleteAllFiles.then(() => {
    
    fs.rmdir('./logs', (err) => {
        if(err){
            console.log(err);
        } else {
            console.log('Directory removed');
        }
    });
    
}).catch((err) => {
   
    console.log(err);
    
});

