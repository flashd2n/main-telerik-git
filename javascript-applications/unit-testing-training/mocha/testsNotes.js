'use strict';

//const sum = require('./script');
//const chai = require('chai');
mocha.setup('bdd');
const expect = chai.expect;

describe('Category One', function () {
    it('Test One', function () {


        //        chai.assert(true, 'message');

        const expected = 4;
        const actual = 4;

        expect(actual).to.equal(expected);

    });

});

mocha.run();


// code
function waitASecond() {
    return new Promise(function (resolve, reject) {
        setTimeout(() => {
            resolve(5); // reject(5)
        }, 1000);
    });
}

// test

it('name', function (done) {

    let promise = waitASecond();

    promise.then(function (result) {
        expect(result).to.equal(5);
    }, function (err) {
        expect(err).to.equal(5);
    }).then(done, done);

});


// SINON

describe('Some category', function () {

    beforeEach(() => sinon.stub(console, 'log'));
    afterEach(() => console.log.restore());

    it('first test', function () {

        action();
        action();

        expect(console.log).to.have.callCount(1);

    });

});

///


describe('Some category', function () {

    beforeEach(() => {
        sinon.stub(funcs, 'sum').returns(9);
        sinon.spy(console, 'log');
    });
    afterEach(() => {
        funcs.sum.restore();
        //        console.log.restore();
    });


    it('first test', function () {

        action();

        expect(funcs.sum).to.have.callCount(1);
        expect(funcs.sum).have.been.calledWith(4, 5);

        expect(console.log).to.have.callCount(1);
        expect(console.log).have.been.calledWith(9);


    });

});

////


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
