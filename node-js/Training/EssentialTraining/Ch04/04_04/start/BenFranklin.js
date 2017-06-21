let imp = require('./Person');

//console.log(imp.name);

let gosho = new imp.Person('gosho');

let stamat = new imp.Person('stamat');

gosho.on('speak', function(said){
    console.log('ggosho talks!');
});

stamat.on('speak', function(said){
    console.log('stamat talks!');
});

gosho.emit('speak', 'shiiit');