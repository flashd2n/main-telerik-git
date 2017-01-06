function solve(args) {
    let numOne = Number(args[0]),
        numTwo = Number(args[1]),
        numThree = Number(args[2]),
        result;
    let negative = 0;

    for (let i = 0; i < 3; i += 1) {

        if (args[i] < 0) {
            negative += 1;
        }
    }


    if (numOne === 0 || numTwo === 0 || numThree === 0) {
        result = 0;
    } else if (negative === 0) {
        result = `+`;
    } else if (negative % 2 === 0) {
        result = `+`;
    } else {
        result = `-`;
    }

    console.log(result);
}


solve(['-1', '-0.5', '-5.1']);