interface ISquare {
    color: string,
    width: number,
    doStuff: () => void,
}

const createSquare = (config: ISquare): { color: string, area: number } /* IoutResult */ => {
    return {
        color: config.color,
        area: config.width * 2
    }
}

var config = {
    color: 'black',
    width: 42,
    doStuff: () => {
        console.log('I did stuff')
    }
}

var mySquare = createSquare(config);

console.log(mySquare);

class Square implements ISquare {
    constructor(public color: string, public width: number) { }

    doStuff() {
        console.log('I did stuff');
    }
}

// GENERICS

function identity<T>(arg: T): T {
    return arg;
}

let myId = identity<string>('Gosho');
console.log(myId);


interface IAwesome{

}

function doAwesomeStuff<T extends IAwesome>(arg: T): void {
    // works only for types that implement the interface
    console.log('works for interface!');
}

class Awesomeness {

}

function doAwesomeStuffTwo<T extends Awesomeness> (arg: T) : void {
    // works only for types that implement the class
    console.log('works for class!');
}

doAwesomeStuff({}); // empty object, because the interface defines nothing
doAwesomeStuffTwo(new Awesomeness());