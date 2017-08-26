let firstName: string = 'Pesho';
let age: number = 20;

let firstSentance: string = `My name is ${firstName}.`;
let lastSentence: string = `I am ${age} years old`;

function printTwoSentences(firstSentance: string, lastSentence: string) {
    console.log(`${firstSentance} ${lastSentence}`);
}

printTwoSentences(firstSentance, lastSentence);


let list: number[] = [1, 2, 3, 4];

enum Color {
    Red = 1,
    Green = 2,
    Blue = 3
}

let myColorAsNumber: Color = Color.Blue;
console.log(myColorAsNumber);

let myColorAsString: string = Color[Color.Green];
console.log(myColorAsString);

// UNIONS

let myUnion: (number | string);
myUnion = 'pesho';
myUnion = 43;

let newList: (number | string)[] = [1, 2, 3, 'pesho'];

// TUPLE

let myTuple: [string, number];
myTuple = ['pesho', 2];
// myTuple = [2, 'pesho']; -> does not work


// FUNCTIONS

function add(x: number, y: number): number {
    return x + y;
}

let addTwo = (x: number, y: number): number => {
    return x + y;
}

function warnUser(): void {
    alert('blaaa');
}

let optional = (x: number, y?: number): number => {
    return x;
}

let manyParams = (fName: string, ...manyOtherNames: string[]) : void => {
    console.log('something cool');
}

