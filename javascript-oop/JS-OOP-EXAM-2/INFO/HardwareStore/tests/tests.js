const {expect} = require('chai');
const result = require('../task/task')();

describe('Tests', function() {
	it('Sample test', function() {
		expect(result.getSmartPhone).to.be.a('function');
		expect(result.getSmartPhone).to.have.length(5);

		expect(result.getCharger).to.be.a('function');
		expect(result.getCharger).to.have.length(5);

		expect(result.getRouter).to.be.a('function');
		expect(result.getRouter).to.have.length(5);

		expect(result.getHeadphones).to.be.a('function');
		expect(result.getHeadphones).to.have.length(5);

		expect(result.getHardwareStore).to.be.a('function');
		expect(result.getHardwareStore).to.have.length(1);

		const phone = result.getSmartPhone('HTC', 'One M8', 42, 5, 'Android');
		const charger = result.getCharger('Pesho', 'Gosho', 20, 19, 1000);
		const router = result.getRouter('Gosho', 'Pesho', 80, 30, 5);
		const headphones = result.getHeadphones('Sennheiser', 'HD 598', 340, 'high', false);

		[ phone, charger, router, headphones ]
			.forEach(d => {
				[ 'id', 'manufacturer', 'model', 'price', 'getLabel' ]
					.forEach(p => expect(d).to.have.property(p));

				expect(d.getLabel).to.be.a('function');
				expect(d.getLabel).to.have.length(0);
			});

		expect(phone).to.have.property('screenSize');
		expect(phone).to.have.property('operatingSystem');

		expect(charger).to.have.property('outputVoltage');
		expect(charger).to.have.property('outputCurrent');

		expect(router).to.have.property('wifiRange');
		expect(router).to.have.property('lanPorts');

		expect(headphones).to.have.property('quality');
		expect(headphones).to.have.property('hasMicrophone');

		const store = result.getHardwareStore('Technomarket');
		
		expect(store).to.have.property('name');

		[ 'stock', 'sell', 'getSold', 'search' ]
			.forEach(p => {
				expect(store).to.have.property(p);
				expect(store[p]).to.be.a('function');
			});
	});
});
