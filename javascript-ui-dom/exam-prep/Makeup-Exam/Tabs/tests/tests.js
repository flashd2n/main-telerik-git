'use strict';

var chai = require('chai'),
    expect = chai.expect,
    jsdom = require('jsdom'),
    jq = require('jquery'),
    result = require('../task/solution')();

describe('Tabs tests', function () {

    before(function (done) {

        jsdom.env({
            html: '',
            done: function (errors, window) {

                global.window = window;
                global.document = window.document;
                global.$ = jq(window);

                Object
                    .keys(window)
                    .filter(function (p) {
                        return p.toLowerCase().indexOf('html') >= 0;
                    })
                    .forEach(function (p) {
                        global[p] = window[p];
                    });

                done();
            }
        });

    });

    beforeEach(function prep() {
        
    });
  
    describe('Zero tests', function () {

        describe('DOM structure', function () {
            
            it('should generate correct navigation', function () {

                var test01 = require('./split-tests/test.001');

                test01(result, document, $, expect);

            });

            it('should generate correct tabs content', function () {

                var test02 = require('./split-tests/test.002');

                test02(result, document, $, expect);
            });

        });

        describe('Tab opening', function () {

            it('should display correct tab content on .tab-link click', function () {

                var test03 = require('./split-tests/test.003');

                test03(result, document, $, expect);

            });

        });

        describe('Edit button', function () {

            it('should add textarea with correct content to the DOM and rename edit button correctly', function () {

                var test04 = require('./split-tests/test.004');

                test04(result, document, $, expect);

            });

        });

        describe('Save button', function () {

            it('should set content to textarea value and change button text to "Edit" when "Save" is clicked', function () {

                var test05 = require('./split-tests/test.005');

                test05(result, document, $, expect);
            });

        });

    });

});