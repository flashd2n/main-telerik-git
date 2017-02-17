'use strict';

class Animal {
    constructor(name) {
        this._name = name;
    }

    get name() {
        return this._name;
    }

    eat() {
        console.log(`Eating...`);
    }
}

class Dog extends Animal {
    constructor(name) {
        super(name);
    }

    bark() {
        console.log(`bark bark ${this._name}`);
    }

    eat() {
        super.eat();
        console.log(`${this._name} sleeps after eating`);
    }
}

let myDog = new Dog('Berg');
myDog.bark();
myDog.eat();


// MIXINS

class Text {
    constructor(content) {
        this._content = content;
    }

    get content() {
        return this._content;
    }

}

class Image {
    constructor() {

    }
}

class ClickableImage extends Image {

}

function makeClickable(base) {
    class Extension extends base {
        constructor(url, ...args) {
            super(...args);
            this._url = url;
        }

        Click() {
            console.log(`going to ${this._url}`);
        }
    }
    return Extension;
}

// class ClickableText extends Text{
//     constructor(url, ...args){
//         super(...args);
//         this._url = url;
//     }

//     Click(){
//         console.log(`going to ${this._url}`);
//     }
// }

// let myClickableText = new ClickableText(`someUrl`, `content for text`);
// myClickableText.Click();

let myClickableText = makeClickable(Text); // not working