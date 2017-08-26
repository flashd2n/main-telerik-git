"use strict";
var firstName = 'Pesho';
var age = 20;
var firstSentance = "My name is " + firstName + ".";
var lastSentence = "I am " + age + " years old";
function printTwoSentences(firstSentance, lastSentence) {
    console.log(firstSentance + " " + lastSentence);
}
printTwoSentences(firstSentance, lastSentence);
var list = [1, 2, 3, 4];
var Color;
(function (Color) {
    Color[Color["Red"] = 1] = "Red";
    Color[Color["Green"] = 2] = "Green";
    Color[Color["Blue"] = 3] = "Blue";
})(Color || (Color = {}));
var myColorAsNumber = Color.Blue;
console.log(myColorAsNumber);
var myColorAsString = Color[Color.Green];
console.log(myColorAsString);
// UNIONS
var myUnion;
myUnion = 'pesho';
myUnion = 43;
var newList = [1, 2, 3, 'pesho'];
// TUPLE
var myTuple;
myTuple = ['pesho', 2];
// myTuple = [2, 'pesho']; -> does not work
// FUNCTIONS
function add(x, y) {
    return x + y;
}
var addTwo = function (x, y) {
    return x + y;
};
function warnUser() {
    alert('blaaa');
}
var optional = function (x, y) {
    return x;
};
var manyParams = function (fName) {
    var manyOtherNames = [];
    for (var _i = 1; _i < arguments.length; _i++) {
        manyOtherNames[_i - 1] = arguments[_i];
    }
    console.log('something cool');
};
//# sourceMappingURL=index.js.map