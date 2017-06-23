let fs = require('fs');

if(fs.existsSync('lib')){
    
   console.log('Directory already there');
    
} else{
    fs.mkdir('lib', (err) => {
   
        if(err){
           console.log(err);
        } else {
            console.log('directory created');
        }
    
    });
}