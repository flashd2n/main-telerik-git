'use strict';

//define an object
let person = {
    name: `Gosho`,
    age: 32,
    grades: [1, 2, 3, 4, 5, 6],
    getOlder: function(){
        this.age += 1;
    }
};

console.log(person.age);
person.getOlder();
console.log(person.age);

// define objectBuilder

function MakePerson(name, age){
    return {
        name: name,
        age: age,
        getOlder: function(){
            this.age += 1;
        }
    }
}

let tosho = MakePerson(`tosho toshev`, 43);
let geno = MakePerson(`geno genov`, 12);

console.log(tosho);
tosho.getOlder();
console.log(tosho.age);
console.log(geno);