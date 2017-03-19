'use strict';

function solve() {

  var VALIDATION = {
    validateSelector: function(value){
      if(typeof value !== 'string'){
        throw new Error('Invalid selector');
      }
    },
    validateCount: function(value){
      if(typeof value !== 'number' && Number.isNaN(Number(value))){
        throw new Error('Invalid Count');
      }
      if(Number(value) < 1){
        throw new Error('Count is less that one');
      }
    }
  };


  return function (selector, count) {
   VALIDATION.validateSelector(selector);
   VALIDATION.validateCount(count);
   count = Number(count);

   var ulElement = $('<ul></ul>');
   ulElement.addClass('items-list');

   for(var i = 0; i < count; i++){

    var liElement = $('<li></li');
    liElement.addClass('list-item')
    .html('List item #' + i);
    
    ulElement.append(liElement);

   }

   $(selector).append(ulElement);

  };
}

module.exports = solve;