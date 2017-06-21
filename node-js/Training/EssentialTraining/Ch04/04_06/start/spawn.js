let spawn = require('child_process').spawn;

let childProcess = spawn('node', ['alwaysTalking']);

const RESPONSE_TIME = 4000;

childProcess.stdout.on('data', function(data){
   console.log(`From child: ${data}`); 
});

childProcess.on('exit', function(){
   
    console.log('Child done');
    process.exit();
    
});

setTimeout(function(){
    
    childProcess.stdin.write('stop');
    
}, RESPONSE_TIME);