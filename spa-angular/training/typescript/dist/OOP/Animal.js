"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Animal = (function () {
    // private readonly name: string;
    // public constructor(name: string) {
    //     this.name = name;
    // }
    function Animal(name) {
        this.name = name;
        // this.name = name;
    }
    Object.defineProperty(Animal.prototype, "Name", {
        get: function () {
            return this.name;
        },
        enumerable: true,
        configurable: true
    });
    // public set Name(value: string){
    //     this.name = value;
    // }
    Animal.prototype.move = function (distanceInMeters) {
        if (distanceInMeters === void 0) { distanceInMeters = 0; }
        console.log(this.name + " moved " + distanceInMeters + " meters!");
    };
    return Animal;
}());
var Snake = (function (_super) {
    __extends(Snake, _super);
    function Snake(name) {
        return _super.call(this, name) || this;
    }
    Snake.prototype.move = function (distanceInMeters) {
        if (distanceInMeters === void 0) { distanceInMeters = 5; }
        console.log('Slithering...');
        _super.prototype.move.call(this, distanceInMeters);
    };
    return Snake;
}(Animal));
// let sam = new Snake('Pesho');
// let otherSam: Animal = new Snake('Gosho');
var testMe = new Snake('Pesho');
// testMe.Name = 'Gosho';
var whatName = testMe.Name;
//# sourceMappingURL=Animal.js.map