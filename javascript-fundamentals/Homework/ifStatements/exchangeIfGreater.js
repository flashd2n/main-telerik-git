function solve(args){
    let numOne = Number(args[0]),
        numTwo = Number(args[1]),
        result;
    
    if(numOne > numTwo){
        result = `${numTwo} ${numOne}`;
    } else {
        result = `${numOne} ${numTwo}`;
    }
    console.log(result);
}