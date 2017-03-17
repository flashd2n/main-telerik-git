/* globals $ */

/* 

Create a function that takes an id or DOM element and:
  

*/

'use strict';

function solve() {

  var VALIDATION = {
    validateSelector: function (value) {
      if (typeof value !== 'string' && !(value instanceof HTMLElement)) {
        throw new Error('Invalid selector');
      }
    },
    validateDomElement: function(value){
      if(value === null){
        throw new Error('Not existing element');
      }
    }
  };

  return function (selector) {

    VALIDATION.validateSelector(selector);
    if (typeof selector === 'string') {
      selector = document.getElementById(selector);
    }
    VALIDATION.validateDomElement(selector);

    var allButtons = [].slice.call(document.querySelectorAll('.button'));

    allButtons.forEach(function (button) {

      button.innerHTML = 'hide';

    });

    document.getElementById('root').addEventListener('click', eventHandler, false);

    function eventHandler(event) {

      if (event.target.className === 'button') {

        var target = event.target;
        var content = target;

        while (content) {

          if (content.className === 'content') {
            break;
          }
          content = content.nextElementSibling;

        }

        if (content.style.display === '') {
          target.innerHTML = 'show';
          content.style.display = 'none';
        } else if(content.style.display === 'none') {
          target.innerHTML = 'hide';
          content.style.display = '';
        }
      }
    }
  };
}

module.exports = solve;