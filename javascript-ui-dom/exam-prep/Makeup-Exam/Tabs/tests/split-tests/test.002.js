module.exports = function (result, document, $, expect) {
    
    document.body.innerHTML = '<div id="container"></div>';

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

    var tabContents = $('#container ul.tabs-content li.tab-content');

    expect(tabContents.length).to.equal(tabs.length);

    tabContents.each(function (index, tab) {
        var $tab = $(tab);

        expect($tab.find('p').text()).to.equal(tabs[index].content);
        expect($tab.find('button.btn-edit').text()).to.equal('Edit');
    });
};