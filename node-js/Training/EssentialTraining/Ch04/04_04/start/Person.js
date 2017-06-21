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

module.exports = {
    Person: Person,
    name: 'lala land'
};