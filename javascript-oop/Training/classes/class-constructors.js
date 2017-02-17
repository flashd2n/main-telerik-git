'use strict';


class Person{
    constructor(name, age){
        this._name = name;
        this._age = age;
    }
}

let myPerson = new Person(`Stamat`, 28);


console.log(myPerson);

