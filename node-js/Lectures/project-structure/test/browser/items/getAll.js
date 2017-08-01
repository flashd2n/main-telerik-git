const { expect } = require('chai');
const { setupDriver } = require('../utils/setup.driver');

describe('SOMETHING', () => {
    let driver = null;
    beforeEach(() => {
        driver = setupDriver('chrome');
    });

    it('FIRST', () => {
        return driver.get('http://telericacademy.com')
            .then(() => {
                return driver.getTitle();
            })
            .then((title) => {
                console.log(title);
                expect(title).not.to.be.undefined;
            });
    });
});
