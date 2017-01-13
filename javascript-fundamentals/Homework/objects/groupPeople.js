'use strict';

function solve(args){
    
    let grouped = group(args);

    console.log(grouped);

    function group(people){
        let result = {};

        for(let item of people){

            if(result.hasOwnProperty(item.age)){
                result[item.age].push(item);
            } else{
                result[item.age] = [];
                result[item.age].push(item);
            }

        }
        return result;
    }

}

let people = [
  { firstname: 'Gosho', lastname: 'Petrov', age: 32 },
  { firstname: 'Bay', lastname: 'Ivan', age: 81 },
  { firstname: 'John', lastname: 'Doe', age: 42 },
  { firstname: 'Pesho', lastname: 'Pesho', age: 22 },
  { firstname: 'Asdf', lastname: 'Xyz', age: 81 },
  { firstname: 'Gosho', lastname: 'Gosho', age: 22 }
];


solve(people);