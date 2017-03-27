module.exports = function (result, document, $, expect) {

    function triggerClickOn(element) {
        var clickEvent = document.createEvent('Event');
        clickEvent.initEvent('click', true, true);

        element.dispatchEvent(clickEvent);
    }

    document.body.innerHTML = '<div id="container"></div>';

    var tabs = [
        { title: 'C#', content: 'Modern object oriented language running on the .NET platform' },
        { title: 'JavaScript', content: 'Weakly typed scripting language that can be used for web pages and server side' },
        { title: 'C++', content: 'High performance language that can be used for almost everything' },
        { title: 'Java', content: 'Cross-platform object oriented language that has a huge community. Lives by the paradigm "Write once, debug everywhere"' }
    ];

    var jqstore = $;

    $ = jQuery = undefined;

    result('#container', tabs);

    $ = jQuery = jqstore;

    expect($('textarea').length).to.be.zero;

    var navLis = $('#container ul.tabs-nav li a.tab-link');

    expect(navLis.length).to.equal(tabs.length);

    navLis.each(function (index, link) {
        triggerClickOn(link);

        var $visible = $('#container ul.tabs-content .tab-content.visible');

        expect($visible.length).to.equal(1);
        expect($visible.find('p').text()).to.equal(tabs[index].content);

        var $editBtn = $visible.find('button.btn-edit');

        triggerClickOn($editBtn.get(0));

        expect($editBtn.text()).to.equal('Save');

        var $textarea = $visible.find('textarea');

        expect($textarea.length).to.equal(1);
        expect($textarea.hasClass('edit-content')).to.be.true;
        expect($textarea.val()).to.equal($visible.find('p').text());

        $textarea.val($textarea.val() + ' and is a very cool programming language');

        var newContent = $textarea.val();

        triggerClickOn($editBtn.get(0));

        expect($('textarea').length).to.be.zero;

        expect($visible.find('p').text()).to.equal(newContent);

        expect($editBtn.text()).to.equal('Edit');
    });
};