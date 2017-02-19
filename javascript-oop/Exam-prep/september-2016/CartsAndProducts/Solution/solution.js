'use strict';

function solve() {

    class Product {
        constructor(productType, name, price) {
            this.productType = productType;
            this.name = name;
            this.price = price;
        }

        set productType(value) {
            this._productType = value;
        }
        get productType() {
            return this._productType;
        }
        set name(value) {
            this._name = value;
        }
        get name() {
            return this._name;
        }
        set price(value) {
            this._price = value;
        }
        get price() {
            return this._price;
        }

    }

    class ShoppingCart {

        constructor() {
            this._products = [];
        }
        get products() {
            return this._products;
        }

        add(product) {
            this.products.push(product);
            return this;
        }
        remove(product) {
            if (this.products.length === 0) {
                throw new Error('cannot remove from empty cart');
            }

            let indexToRemove = this.products.findIndex(x => x.name === product.name && x.price === product.price && x.productType === product.productType);
            if (indexToRemove < 0) {
                throw new Error('product to remove not found');
            }

            this.products.splice(indexToRemove, 1);
            return this;

        }
        showCost() {

            return this.products.reduce((x, y) => x + y.price, 0);

        }
        showProductTypes() {

            return this.products.map(x => x.productType).slice().sort().filter((item, index, array) => item !== array[index - 1]).sort();

        }
        getInfo() {

            let result = [];
            for (let i = 0; i < this.products.length; i++) {
            let foundIndex = 0;
            let inResult = false;
                if (result.length === 0) {
                    result.push({
                        name: this.products[i].name,
                        totalPrice: this.products[i].price,
                        quantity: 1
                    });
                    continue;
                }

                for (let j = 0; j < result.length; j++) {
                    if (this.products[i].name === result[j].name) {
                        inResult = true;
                        foundIndex = j;
                        break;
                    }
                }

                if (!inResult) {
                    result.push({
                        name: this.products[i].name,
                        totalPrice: this.products[i].price,
                        quantity: 1
                    });
                } else {
                    result[foundIndex].totalPrice += this.products[i].price;
                    ++result[foundIndex].quantity;
                }

            }

            result.sort(function(x, y){
                if(x.name > y.name){
                    return 1;
                } else if(x.name < y.name){
                    return -1;
                } else{
                    return 0;
                }
            });

            return {
                totalPrice: this.showCost(),
                products: result
            };

        }
    }
    return {
        Product, ShoppingCart
    };
}