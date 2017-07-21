class Item {

    static createInstance(data) {
        return new this();
    }
}

const something = Item.createInstance();

console.log(something);
