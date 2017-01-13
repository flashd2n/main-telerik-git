'use strict';

function solve(args){
    let peopleArray = [];
    
    for(let i = 0; i < args.length; i += 3){
        peopleArray.push({
            firstname: args[i],
            lastname: args[i + 1],
            age: Number(args[i + 2])
        });
    }

    let youngestIndex = 0,
        youngestAge = Number.MAX_SAFE_INTEGER;

    for(let i = 0; i < peopleArray.length; i++){

        if(peopleArray[i].age < youngestAge){
            youngestAge = peopleArray[i].age;
            youngestIndex = i;
        }
    }
    console.log(`${peopleArray[youngestIndex].firstname} ${peopleArray[youngestIndex].lastname}`);
    console.log(peopleArray[youngestIndex]['firstname'] + ' ' + peopleArray[youngestIndex]['lastname']); // using associative arrays
}

solve(['Gosho','Petrov','32','Bay','Ivan','81','John','Doe','42']);