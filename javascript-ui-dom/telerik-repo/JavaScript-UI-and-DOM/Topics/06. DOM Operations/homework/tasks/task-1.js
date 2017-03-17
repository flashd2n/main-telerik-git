/* globals $ */

/* 

Create a function that takes an id or DOM element and an array of contents

* if an id is provided, select the element
* Add divs to the element
  * Each div's content must be one of the items from the contents array
* The function must remove all previous content from the DOM element provided
* Throws if:
  * The provided first parameter is neither string or existing DOM element
  * The provided id does not select anything (there is no element that has such an id)
  * Any of the function params is missing
  * Any of the function params is not as described
  * Any of the contents is neight `string` or `number`
    * In that case, the content of the element **must not be** changed   
*/

'use strict';

module.exports = function solve (element, contents) {

  const VALIDATION = {
    validateElement: function(value){

      if(typeof value !== 'string' && !(value instanceof HTMLElement)){
        throw new Error ('The passed element is not valid');
      }
    },
    validateContents: function(value){
      value.forEach(function(content){

        if(typeof content !== 'string' && typeof content !== 'number'){
          throw new Error('Invalid contents');
        }
      });
    }
  };

  return function (element, contents) {

    VALIDATION.validateElement(element);
    VALIDATION.validateContents(contents);
    if(typeof element === 'string'){
      element = document.getElementById(element);
    }
    if(element === null){
      throw new Error('Invalid ID');
    }
    if(arguments.length !== 2){
      throw new Error('Invalid parameters');
    }

    while (element.firstChild) {
        element.removeChild(element.firstChild);
    }

    contents.forEach(function(content){

      var tempDiv = document.createElement('div');
      tempDiv.innerHTML = content;
      element.appendChild(tempDiv);

    });
  };
};