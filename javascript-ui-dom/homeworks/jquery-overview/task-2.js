/* globals $ */

/*
Create a function that takes a selector and:
* Finds all elements with class `button` or `content` within the provided element
  * Change the content of all `.button` elements with "hide"
* When a `.button` is clicked:
  * Find the topmost `.content` element, that is before another `.button` and:
    * If the `.content` is visible:
      * Hide the `.content`
      * Change the content of the `.button` to "show"       
    * If the `.content` is hidden:
      * Show the `.content`
      * Change the content of the `.button` to "hide"
    * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
* Throws if:
  * The provided ID is not a **jQuery object** or a `string` 

*/

'use strict';

function solve() {

  var VALIDATION = {
    valudateSelector: function(value){
      if(typeof value !== 'string' && !(value instanceof jQuery)){
        throw new Error('Invalid selector');
      }
    }
  };

  return function (selector) {
    VALIDATION.valudateSelector(selector);

    if($(selector).length === 0){
      throw new Error('No such element');
    }

    var $allButtons = $(selector + ' .button')
    .html('hide');

    $allButtons.click(function(event){

      var button = $(this);
      var content = button;

      while (!(content.hasClass('content')) && content.length !== 0) {
        content = content.next();
      }

      if(content.css('display') === 'none'){
        content.css('display', '');
        button.html('hide');
      } else {
        content.css('display', 'none');
        button.html('show');
      }
    });
  };
}

module.exports = solve;