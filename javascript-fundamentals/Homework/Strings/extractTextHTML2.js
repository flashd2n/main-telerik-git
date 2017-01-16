'use strict';

function solve(args) {
    let output = '';
    let tagSelector = /<.*?>/ig;

    for (let line of args) {
        output += line.replace(tagSelector, '').trim();
    }

    console.log(output);
}


solve([
  '<html>',
  '  <head>',
  '    <title>Sample site</title>',
  '  </head>',
  '  <body>',
  '    <div>text',
  '      <div>more text</div>',
  '      and more...',
  '    </div>',
  '    in body',
  '  </body>',
  '</html>'
]);