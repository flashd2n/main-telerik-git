var expect = require("chai").expect;
var tools = require("../lib/tools");
const nock = require('nock');

describe("Tools", function() {

	describe("printName()", function() {
		it("should print the last name first", function() {
			var results = tools.printName({ first: "Alex", last: "Banks"});
			expect(results).to.equal("Banks, Alex");
		});
	});

	describe("loadWiki()", function() {

		this.timeout(5000);

        before(function(){
           
            nock('https://en.wikipedia.org')
                .get('/wiki/Abraham_Lincoln')
                .reply(200, 'Valid Response');
            
        });
        
		it("Load Abraham Lincoln's wikipedia page", function(done) {

			tools.loadWiki({ first: "Abraham", last: "Lincoln"}, function(html) {
				expect(html).to.equal('Valid Response')
				done();
			});

		});

	});

});


