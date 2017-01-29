'use strict';

let point = {
    x: 1.0,
    y: 1.0,

    get r(){
        return Math.sqrt(this.x * this.x + this.y * this.y);
    },
    set r(value){
        let oldValue = Math.sqrt(this.x * this.x + this.y * this.y);
        let ratio = value / oldValue;
        this.x *= ratio;
        this.y *= ratio;
    }
};


console.log(point.r);

point.r = 20;

console.log(point);
console.log(point.r);

