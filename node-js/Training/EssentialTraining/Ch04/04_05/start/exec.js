let exec = require('child_process').exec;

exec('ls -la', function(err, stdout){
    
    if(err){
        throw err;
    }
    
    console.log('finished')
    console.log(stdout);
    
});
