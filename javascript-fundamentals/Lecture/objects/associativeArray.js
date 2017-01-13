'use strict';

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

console.log(tosho.name); // access property of object with DOT operator
console.log(tosho[`name`]); // access property of object with indexing -> pass property name as string
