module.exports = function (result, document, $, expect) {
    
    $('<div />', { id: 'container' }).appendTo(document.body);

    var tabs = [
        { title: 'Gosho', content: 'Superhero from Kazichene' },
        { title: 'Ivan', content: 'Criminal from Goren Okol' },
        { title: 'Stamat', content: 'Crime lord from Burgas' },
        { title: 'Stanislav', content: 'Travelling salesman from Busmantsi' }
    ];

    var jqstore = $;

    $ = jQuery = undefined;

    result('#container', tabs);

    $ = jQuery = jqstore;

    var navLis = $('#container ul.tabs-nav li a.tab-link');

    expect(navLis.length).to.equal(tabs.length);

    navLis.each(function (index, link) {
        var $link = $(link);

        expect($link.hasClass('tab-link')).to.be.true;
        expect($link.text()).to.equal(tabs[index].title);
    });

};