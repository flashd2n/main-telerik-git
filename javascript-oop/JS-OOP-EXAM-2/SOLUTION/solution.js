'use strict';

function solve() {

	const generateID = (function () {
		let id = 0;
		return function () {
			++id;
			return id;
		};
	})();

	const VALIDATION = {
		validateString: function (input) {
			if (typeof input !== 'string') {
				throw new Error('This is not a string');
			}
		},
		validateStringLength: function (input, min, max) {
			this.validateString(input);
			if (input.length < min || input.length > max) {
				throw new Error('The string is outside set boudnaries');
			}
		},
		validatePositiveNonZeroNumber: function (input) {
			if (typeof input !== 'number' || isNaN(input)) {
				throw new Error('This is not a number');
			}
			if (input <= 0) {
				throw new Error('This is not a positive, non-zero number');
			}
		},
		validateNumberRange: function (input, min, max) {
			if (typeof input !== 'number' || isNaN(input)) {
				throw new Error('This is not a number');
			}
			if (input < min || input > max) {
				throw new Error('The number is outside set boundaries');
			}
		},
		validatePositiveNonZeroIntegerNumber: function (input) {
			this.validatePositiveNonZeroNumber(input);
			if (!Number.isInteger(input)) {
				throw new Error('This is not a positive, non zero INTEGER number');
			}
		},
		validateQuality: function (input) {
			this.validateString(input);
			if (input !== 'high' && input !== 'mid' && input !== 'low') {
				throw new Error('This is not a valid quality value');
			}
		},
		validateProductInstance: function (input) {
			if (!(input instanceof Product)) {
				throw new Error('This is not an instance of the product class');
			}
		}
	};

	class Product {
		constructor(manufacturer, model, price) {
			this._id = generateID();
			this.manufacturer = manufacturer;
			this.model = model;
			this.price = price;
		}

		get id() {
			return this._id;
		}

		get manufacturer() {
			return this._manufacturer;
		}
		set manufacturer(value) {
			VALIDATION.validateStringLength(value, 1, 20);
			this._manufacturer = value;
		}

		get model() {
			return this._model;
		}
		set model(value) {
			VALIDATION.validateStringLength(value, 1, 20);
			this._model = value;
		}

		get price() {
			return this._price;
		}
		set price(value) {
			VALIDATION.validatePositiveNonZeroNumber(value);
			this._price = value;
		}

		getLabel() {
			return '';
		}
	}

	class SmartPhone extends Product {
		constructor(manufacturer, model, price, screenSize, operatingSystem) {
			super(manufacturer, model, price);
			this.screenSize = screenSize;
			this.operatingSystem = operatingSystem;
		}

		get screenSize() {
			return this._screenSize;
		}
		set screenSize(value) {
			VALIDATION.validatePositiveNonZeroNumber(value);
			this._screenSize = value;
		}

		get operatingSystem() {
			return this._operatingSystem;
		}
		set operatingSystem(value) {
			VALIDATION.validateStringLength(value, 1, 10);
			this._operatingSystem = value;
		}

		getLabel() {
			const result = 'SmartPhone - ' + this.manufacturer + ' ' + this.model + ' - ' + '**' + this.price + '**';
			return result;
		}
	}

	class Charger extends Product {
		constructor(manufacturer, model, price, outputVoltage, outputCurrent) {
			super(manufacturer, model, price);
			this.outputVoltage = outputVoltage;
			this.outputCurrent = outputCurrent;
		}

		get outputVoltage() {
			return this._outputVoltage;
		}
		set outputVoltage(value) {
			VALIDATION.validateNumberRange(value, 5, 20);
			this._outputVoltage = value;
		}

		get outputCurrent() {
			return this._outputCurrent;
		}
		set outputCurrent(value) {
			VALIDATION.validateNumberRange(value, 100, 3000);
			this._outputCurrent = value;
		}

		getLabel() {
			const result = 'Charger - ' + this.manufacturer + ' ' + this.model + ' - ' + '**' + this.price + '**';
			return result;
		}
	}

	class Router extends Product {
		constructor(manufacturer, model, price, wifiRange, lanPorts) {
			super(manufacturer, model, price);
			this.wifiRange = wifiRange;
			this.lanPorts = lanPorts;
		}

		get wifiRange() {
			return this._wifiRange;
		}
		set wifiRange(value) {
			VALIDATION.validatePositiveNonZeroNumber(value);
			this._wifiRange = value;
		}

		get lanPorts() {
			return this._lanPorts;
		}
		set lanPorts(value) {
			VALIDATION.validatePositiveNonZeroIntegerNumber(value);
			this._lanPorts = value;
		}

		getLabel() {
			const result = 'Router - ' + this.manufacturer + ' ' + this.model + ' - ' + '**' + this.price + '**';
			return result;
		}
	}

	class Headphones extends Product {
		constructor(manufacturer, model, price, quality, hasMicrophone) {
			super(manufacturer, model, price);
			this.quality = quality;
			this.hasMicrophone = hasMicrophone;
		}

		get hasMicrophone() {
			return this._hasMicrophone;
		}
		set hasMicrophone(value) {
			if (value) {
				this._hasMicrophone = true;
			} else {
				this._hasMicrophone = false;
			}
		}

		get quality() {
			return this._quality;
		}
		set quality(value) {
			VALIDATION.validateQuality(value);
			this._quality = value;
		}

		getLabel() {
			const result = 'Headphones - ' + this.manufacturer + ' ' + this.model + ' - ' + '**' + this.price + '**';
			return result;
		}
	}

	class HardwareStore {
		constructor(name) {
			this.name = name;
			this._products = [];
			this._trackQuantity = [];
			this._showMeTheMoney = 0;
		}

		get showMeTheMoney() {
			return this._showMeTheMoney;
		}
		set showMeTheMoney(value){
			this._showMeTheMoney = value;
		}
		get products() {
			return this._products;
		}
		get trackQuantity() {
			return this._trackQuantity;
		}

		get name() {
			return this._name;
		}
		set name(value) {
			VALIDATION.validateStringLength(value, 1, 20);
			this._name = value;
		}

		stock(product, quantity) {
			VALIDATION.validateProductInstance(product);
			VALIDATION.validatePositiveNonZeroIntegerNumber(quantity);

			const productIndex = this.trackQuantity.findIndex(x => x.id === product.id);

			if (productIndex >= 0) {
				this.trackQuantity[productIndex].quantity += quantity;
				return this;
			}

			this.products.push(product);

			this.trackQuantity.push({
				id: product.id,
				quantity: quantity
			});

			return this;
		}

		sell(productId, quantity) {
			VALIDATION.validatePositiveNonZeroIntegerNumber(quantity);
			VALIDATION.validatePositiveNonZeroIntegerNumber(productId);

			const productIndex = this.trackQuantity.findIndex(x => x.id === productId);

			if (productIndex < 0) {
				throw new Error('There is not such product in the store');
			}

			if (this.trackQuantity[productIndex].quantity < quantity) {
				throw new Error('There is not enough product in the store');
			}

			const productPrice = this.products.find(x => x.id === productId).price;

			this.trackQuantity[productIndex].quantity -= quantity;
			this.showMeTheMoney = this.showMeTheMoney + productPrice * quantity;

			if(this.trackQuantity[productIndex].quantity === 0){
				let indexToRemove = this.products.findIndex(x => x.id === productId);
				this.products.splice(indexToRemove, 1);
			}

			return this;
		}

		getSold() {
			return this.showMeTheMoney;
		}

		search(query) {
			let result = [];
			let productsToReturn = [];

			if (typeof query === 'object') {
				productsToReturn = this.products.filter(function (product) {

					return (!query.hasOwnProperty('manufacturerPattern') || product.manufacturer.indexOf(query.manufacturerPattern) >= 0) &&
						(!query.hasOwnProperty('modelPattern') || product.model.indexOf(query.modelPattern) >= 0) &&
						(!query.hasOwnProperty('type') || product.constructor.name === query.type) &&
						(!query.hasOwnProperty('minPrice') || product.price >= query.minPrice) &&
						(!query.hasOwnProperty('maxPrice') || product.price <= query.maxPrice);
				});
			}

			if (typeof query === 'string') {

				result = [];
				productsToReturn = this.products.filter(function (product) {
					return product.model.toLowerCase().indexOf(query.toLowerCase()) >= 0 || product.manufacturer.toLowerCase().indexOf(query.toLowerCase()) >= 0;
				});
			}


			let self = this;

			productsToReturn.forEach(function (product) {

				let isInResult = result.findIndex(x => x.product.id === product.id);

				if (isInResult < 0) {

					let foundQuantity = self.trackQuantity.find(x => x.id === product.id);

					result.push({
						product: product,
						quantity: foundQuantity.quantity
					});
				}
			});
			return result;
		}
	}

	return {
		getSmartPhone(manufacturer, model, price, screenSize, operatingSystem) {
			return new SmartPhone(manufacturer, model, price, screenSize, operatingSystem);
		},
		getCharger(manufacturer, model, price, outputVoltage, outputCurrent) {
			return new Charger(manufacturer, model, price, outputVoltage, outputCurrent);
		},
		getRouter(manufacturer, model, price, wifiRange, lanPorts) {
			return new Router(manufacturer, model, price, wifiRange, lanPorts);
		},
		getHeadphones(manufacturer, model, price, quality, hasMicrophone) {
			return new Headphones(manufacturer, model, price, quality, hasMicrophone)
		},
		getHardwareStore(name) {
			return new HardwareStore(name);
		}
	};
}

const result = solve();



const phone = result.getSmartPhone('HTC', 'One', 10, 5, 'Android');
const charger = result.getCharger('someCharger', 'chargerMan', 20, 15, 1500);
const router = result.getRouter('someRouter', 'routerMan', 30, 100, 3);
const headphones = result.getHeadphones('Sennheiser', 'PXC 550 Wireless', 40, 'high', false);


const store = result.getHardwareStore('Magazin');

store.stock(phone, 5)
	.stock(charger, 5)
	.stock(router, 5)
    .stock(headphones, 5);

console.log(store);


store.sell(1, 2)
	.sell(2, 2)
	.sell(3, 2)
	.sell(4, 2);

console.log(store.getSold());
console.log(store);

// console.log(store.search('senn'));


// console.log(store.search({type: 'SmartPhone', maxPrice: 1000}));


// console.log(store.search({type: 'SmartPhone', maxPrice: 900}));


// store.sell(headphones.id, 2);
// console.log(store.getSold()); // 680

// Submit the code above this line in bgcoder.com
module.exports = solve; // DO NOT SUBMIT THIS LINE
