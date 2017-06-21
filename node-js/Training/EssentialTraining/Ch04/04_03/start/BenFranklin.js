//let events = require('events');
//
//let emitter = new events.EventEmitter();
//
//emitter.on('myAwesomeEvent', function(messsage, status){
//   
//    console.log(messsage);
//    
//    console.log(status);
//    
//});
//
//emitter.emit('myAwesomeEvent', 'cool message?', 'cool status');


let EventEmitter = require('events').EventEmitter;

let util = require('util');

class Person{
    constructor(name){
        this._name = name;
    }
    
    get Name(){
        return this._name;
    }
    
    set Name(value){
        this._name = value;
    }
}

util.inherits(Person, EventEmitter);

let gosho = new Person('gosho');

gosho.on('speak', function(said){
   
    console.log(said);
    console.log(this.Name);
    
});

gosho.emit('speak', 'I can talk!?');