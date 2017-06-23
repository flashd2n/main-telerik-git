let fs = require('fs');

let stream = fs.createReadStream('./chat.log', 'UTF-8');

let data = '';

stream.once('data', () => {
   
    console.log('Reading file');
    
});

stream.on('data', (dataBite) => {
   
    process.stdout.write(`dataBite -> ${dataBite.length}\n`);
    
    data += dataBite;
    
});

stream.on('end', () => {
   console.log(`finished reading -> ${data.length}`); 
});

