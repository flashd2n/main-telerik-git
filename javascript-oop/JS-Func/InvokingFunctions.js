'use strict';

// function invokation

function FuncInvokation(){
    console.log(`function invokation`);
}

FuncInvokation();

// method invokation

let myObject = {
    x: 1,
    y: 2,
    add: function(){
        this.result = this.x + this.y;
    }
};

myObject.add();             // normalno dot invokation
console.log(myObject.result);

myObject[`add`]();          // associative array invokation
console.log(myObject.result);


let testObject = {
    method: function(){
        let self = this;
        console.log(self === testObject);
        secondaryFunction();

        function secondaryFunction(){
            console.log(this === testObject);
            console.log(self === testObject);
        }
    }
};

testObject.method();

// constructor invokation







