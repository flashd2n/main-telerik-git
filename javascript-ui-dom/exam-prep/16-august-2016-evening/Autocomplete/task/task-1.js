/* globals document, window, console */

'use strict';

function solve() {

    return function (selector, initialSuggestions) {

        let availableSuggestions = [];

        if (Array.isArray(initialSuggestions) && initialSuggestions.length > 0) {

            initialSuggestions.forEach(function (suggestion) {
                if (!(availableSuggestions.some(x => x.toLowerCase() === suggestion.toLowerCase()))) {

                    addSuggestion(suggestion);
                    availableSuggestions.push(suggestion);
                }
            });
        }

        var inputSuggestionField = document.querySelector('.tb-pattern');
        var fullList = document.getElementsByClassName('suggestions-list');
        var allSuggestions = fullList[0].children;

        fullList[0].addEventListener('click', function (event) {

            if (event.target.tagName === 'LI' || event.target.tagName === 'A') {

                document.querySelector('.tb-pattern').value = event.target.innerHTML;

            }

        }, false);

        inputSuggestionField.addEventListener('input', function () {

            var inputText = document.querySelector('.tb-pattern').value;

            for (var i = 0; i < allSuggestions.length; i++) {

                var dataName = allSuggestions[i].getAttribute('data-name').toLowerCase();

                if (dataName.indexOf(inputText.toLowerCase()) >= 0) {
                    allSuggestions[i].style.display = '';
                } else {
                    allSuggestions[i].style.display = 'none';
                }
            }
        }, false);

        var addSuggestionButton = document.querySelector('a.btn-add');

        addSuggestionButton.addEventListener('click', function () {

            var inputText = document.querySelector('.tb-pattern').value;

            if (availableSuggestions.some(x => x === inputText) || inputText === '') {
                document.querySelector('.tb-pattern').value = '';
                return;
            }

            addSuggestion(inputText);
            availableSuggestions.push(inputText);
            document.querySelector('.tb-pattern').value = '';
        }, false);

        function addSuggestion(suggestion) {
            var anchorTag = document.createElement('a');
            anchorTag.href = '#';
            anchorTag.className = 'suggestion-link';
            // anchorTag.classList.add('suggestion-link');
            anchorTag.innerHTML = suggestion;

            var listTag = document.createElement('li');
            listTag.className = 'suggestion';
            // listTag.classList.add('suggestion');
            listTag.style.display = 'none';
            // listTag.dataset.name = suggestion;
            listTag.setAttribute('data-name', suggestion);
            listTag.appendChild(anchorTag);

            var suggestionList = document.querySelector('.suggestions-list');
            suggestionList.appendChild(listTag);
        }

    };
}

module.exports = solve;