'use strict';

function solve() {
  return function () {
    $.fn.listview = function (data) {

      // console.log(this.attr('data-template'));   ---> students-row-template
      let templateID = this.attr('data-template');
      $('script').attr('id', templateID);
      let template = $('#' + templateID).html();
      
      let renderer = handlebars.compile(template);

      for(let i = 0; i < data.length; i++){

        let result = renderer(data[i]);
        this.append(result);

      }

      return this;
    };
  };
}

module.exports = solve;