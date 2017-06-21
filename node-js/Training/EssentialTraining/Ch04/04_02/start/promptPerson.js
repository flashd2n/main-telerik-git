let readline = require('readline');

let rl = readline.createInterface(process.stdin, process.stdout);

let person = {
    name: '',
    sayings: []
};

rl.question('What is the name of a real person? ', function(answer){
   
    person.name = answer.toString().trim();
    
    rl.setPrompt(`What would ${person.name} say?`);
    
    rl.prompt();
    
    rl.on('line', function(saying){
        
        if(saying.toString().trim().toLowerCase() === 'exit'){
            
           rl.close();
            
        } else{
            
            person.sayings.push(saying.toString());
        
            rl.setPrompt('What else?')
        
            rl.prompt();
        }
        
        
    });
});

rl.on('close', function(){
    console.log(person.sayings);
    process.exit();
})