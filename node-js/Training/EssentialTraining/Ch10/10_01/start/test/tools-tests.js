'use strict';

const expect = require('chai').expect;
const tools = require('../lib/tools');
const nock = require('nock');


describe('Tools', function () {

    describe('printName() Tests', function () {

        it('Should print the last name first', function () {


            const result = tools.printName({
                first: 'Kalin',
                last: 'Kostov'
            });

            expect(result).to.be.equal('Kostov Kalin');

        });

    });

    describe('Load wiki', function () {

        this.timeout(5000);

        before(function () {

            nock('https://en.wikipedia.org')
                .get('/wiki/Abraham_Lincoln')
                .reply(200, 'Valid Response');

        });


        it('Should load Abr Linc page', function (done) {

            tools.loadWiki({
                first: 'Abraham',
                last: 'Lincoln'
            }, (html) => {

                expect(html).to.equal('Valid Response');
                done();

            });
        });



    });




});
