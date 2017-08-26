"use strict";
var createSquare = function (config) {
    return {
        color: config.color,
        area: config.width * 2
    };
};
var config = {
    color: 'black',
    width: 42,
    doStuff: function () {
        console.log('I did stuff');
    }
};
var mySquare = createSquare(config);
console.log(mySquare);
var Square = (function () {
    function Square(color, width) {
        this.color = color;
        this.width = width;
    }
    Square.prototype.doStuff = function () {
        console.log('I did stuff');
    };
    return Square;
}());
// GENERICS
function identity(arg) {
    return arg;
}
var myId = identity('Gosho');
console.log(myId);
function doAwesomeStuff(arg) {
    // works only for types that implement the interface
    console.log('works for interface!');
}
var Awesomeness = (function () {
    function Awesomeness() {
    }
    return Awesomeness;
}());
function doAwesomeStuffTwo(arg) {
    // works only for types that implement the class
    console.log('works for class!');
}
doAwesomeStuff({}); // empty object, because the interface defines nothing
doAwesomeStuffTwo(new Awesomeness());
//# sourceMappingURL=Interfaces.js.map