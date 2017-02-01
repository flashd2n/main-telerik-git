

function funcOne(args){
    let actual = args.length; // the number of oreceived parameters
    console.log(actual);
    let expected = args.callee.length; // the number of parameters defined in the calling function
    console.log(expected);
}

function mainFunction(x, y, z){
    funcOne(arguments);
    return (x + y + z);
}


mainFunction(1, 2, 3, 4);
console.log(mainFunction.length); // the number of parameters defined in the function definition