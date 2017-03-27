'use strict';

function solve() {
    return function (selector, tabs) {

        var container = document.querySelector(selector);

        var tabsNavigation = document.createElement('ul');
        tabsNavigation.className = 'tabs-nav';

        tabs.forEach(function (tab, index) {
            buildTabNavigation(tab, index);
        });
        container.appendChild(tabsNavigation);

        var tabsContent = document.createElement('ul');
        tabsContent.className = 'tabs-content';

        tabs.forEach(function (tab, index) {
            buildTabContents(tab, index);
        });
        container.appendChild(tabsContent);

        document.querySelector('.tab-content').className += ' visible';

        var allContainers = document.getElementsByClassName('tab-content');

        tabsNavigation.addEventListener('click', function (event) {

            var target = event.target;
            var targetIndex;
            var containerToHide;
            var contentContainerToReveal;
            var containerlength = allContainers.length;

            if (target.className === 'tab-link') {

                containerToHide = document.querySelector('.visible');
                containerToHide.className = 'tab-content';

                targetIndex = target.getAttribute('data-index');

                for (var i = 0; i < containerlength; i++) {
                    if (allContainers[i].getAttribute('data-index') === targetIndex) {
                        contentContainerToReveal = allContainers[i];
                        contentContainerToReveal.className += ' visible';
                        break;
                    }
                }
            }
        }, false);

        tabsContent.addEventListener('click', function (event) {

            var target = event.target;

            if (target.innerHTML === 'Edit') {

                var textArea = document.createElement('textarea');
                textArea.className = 'edit-content';
                target.parentNode.appendChild(textArea);
                var textAreaDefaultContent = target.previousElementSibling.innerHTML;
                textArea.innerHTML = textAreaDefaultContent;

                target.innerHTML = 'Save';

            } else if (target.innerHTML === 'Save') {

                var textArea = target.nextElementSibling;
                var textAreaText = textArea.value;

                target.previousElementSibling.innerHTML = textAreaText;

                textArea.parentNode.removeChild(textArea);

                target.innerHTML = 'Edit';

            }


        }, false);



        function buildTabNavigation(tab, index) {
            var tabContainer = document.createElement('li');
            var tabDetails = document.createElement('a');
            tabDetails.className = 'tab-link';
            tabDetails.innerHTML = tab.title;
            tabDetails.setAttribute('data-index', index);

            tabContainer.appendChild(tabDetails);
            tabsNavigation.appendChild(tabContainer);
        }

        function buildTabContents(tab, index) {
            var tabContentContainer = document.createElement('li');
            tabContentContainer.className = 'tab-content';
            tabContentContainer.setAttribute('data-index', index);

            var tabContent = document.createElement('p');
            tabContent.innerHTML = tab.content;

            var tabButton = document.createElement('button');
            tabButton.className = 'btn-edit';
            tabButton.innerHTML = 'Edit';

            tabContentContainer.appendChild(tabContent);
            tabContentContainer.appendChild(tabButton);
            tabsContent.appendChild(tabContentContainer);
        }

    };
}

// submit the above!

if (typeof module !== 'undefined') {
    module.exports = solve;
}