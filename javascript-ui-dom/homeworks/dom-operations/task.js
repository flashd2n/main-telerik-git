'use strict';

function solve (element, contents) {

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