'use strict';

class Cat{
    constructor(name){
        this.name = name;
        this._canMeow = true;
        this.age = 0;
    }

    get name(){
        return this._name;
    }
    // REAL READ-ONLY PROPERTY
    set name(newName){
        Object.defineProperty(Cat.prototype, `_name`, {
            value: newName,
            writable: false,
            enumerable: false
        });
    }

    get age(){
        return this._age;
    }

    set age(newAge){
        if(newAge < 0){
            throw new Error(`please don't kill cats.`);
        }
        this._age = newAge;
    }

    meow(){
        if(this._canMeow){
            console.log(`${this._name} said ${Cat.WhatDoesTheCatSay()}!`);
        }
    }

    silence(){
        this._canMeow = false;
    }

    unsilence(){
        this._canMeow = true;
    }

    static WhatDoesTheCatSay(){
        return `meow`;
    }

}




let myCat = new Cat(`mariika`);
myCat.meow();
myCat.silence();
myCat.meow();
myCat.unsilence();
myCat.meow();
console.log(myCat.age);
myCat.age = 5;
console.log(myCat.age);
console.log(myCat._name);
// myCat._name = 'gosho';
console.log(myCat._name);
