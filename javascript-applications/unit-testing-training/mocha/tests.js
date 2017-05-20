'use strict';

const {
    action,
    funcs
} = require('./script');

const chai = require('chai');
const sinon = require('sinon');
const expect = chai.expect;
const sinonChai = require('sinon-chai');

chai.use(sinonChai);


describe('Some category', function () {

    let funcsMock;

    beforeEach(() => {
        funcsMock = sinon.mock(funcs);
        sinon.spy(console, 'log');
    });
    afterEach(() => {
        funcsMock.restore();
    });


    it('first test', function () {

        funcsMock.expects('sum').twice();

        funcsMock.expects('sum').never().verify();

        action();
        action();

        funcsMock.verify();


    });

});
