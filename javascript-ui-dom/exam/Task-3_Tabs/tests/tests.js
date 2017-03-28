const { expect } = require('chai');

const { jsdom } = require('jsdom');

const handlebars = require("handlebars");

global.document = jsdom('<html></html>', {});
global.window = document.defaultView;

const solve = require('../task/task');

describe('Test', () => {
    let result;

    beforeEach(() => {
        result = solve();
    })

    describe("Zero tests", () => {
        it('Expect correct structure when no default values are provided', () => {
            document.body.innerHTML = '<div id="root"></div>';
            const root = document.querySelector('#root');

            var template = handlebars.compile(result);
            var data = {
                titles: [{
                    text: "Tab 1",
                    link: "tab-1"
                }, {
                    text: "Tab 2",
                    link: "tab-2"
                }, {
                    text: "Tab 3",
                    link: "tab-3"
                }],
                contents: [{
                    link: "tab-1",
                    text: "Tab 1, no so special...",
                }, {
                    link: "tab-2",
                    text: "<p>Some text in a p</p><a href=\"#\">a link</a>",
                }, {
                    link: "tab-3",
                    text: "<strong>And a list</strong><ul><li>Just</li><li>a</li><li>regular</li><li>list</li></ul>"
                }]
            };

            root.innerHTML = template(data);
            expect(root.firstElementChild.className).to.contains("tabs-control");
            expect(root.querySelectorAll(".list")).to.have.lengthOf("2");
            expect(root.querySelector(".list-titles")).to.not.be.null;
            expect(root.querySelector(".list-contents")).to.not.be.null;
        });
    });
});
