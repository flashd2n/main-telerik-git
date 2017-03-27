module.exports = function (result, document, $, expect) {

    function triggerClickOn(element) {
        var clickEvent = document.createEvent('Event');
        clickEvent.initEvent('click', true, true);

        element.dispatchEvent(clickEvent);
    }

    document.body.innerHTML = '<div id="root"></div>';

    var tabs = [
        { title: 'C#', content: 'Modern object oriented language running on the .NET platform' },
        { title: 'JavaScript', content: 'Weakly typed scripting language that can be used for web pages and server side' },
        { title: 'Java', content: 'Cross-platform object oriented language that has a huge community. Lives by the paradigm "Write once, debug everywhere"' },
        { title: 'Haskell', content: 'Cool purely functional language' }
    ];

    var jqstore = $;

    $ = jQuery = undefined;

    result('#root', tabs);

    $ = jQuery = jqstore;

    var navLis = $('#root ul.tabs-nav li a.tab-link');

    expect(navLis.length).to.equal(tabs.length);

    navLis.each(function (index, link) {

        triggerClickOn(link);

        var $visible = $('#root ul.tabs-content .tab-content.visible');

        expect($visible.length).to.equal(1);

        expect($visible.find('p').text()).to.equal(tabs[index].content);
    });

};