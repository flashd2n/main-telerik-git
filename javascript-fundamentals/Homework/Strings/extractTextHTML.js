'use strict';

function solve(args) {
  let input = args,
    result = '',
    isTag = true;

  for (let index in input) {
    let parse = input[index].trim();
    let len = parse.length;
    for (let i = 0; i < len; i++) {
      let chr = parse[i];

      if (chr === '<') {
        isTag = true;
      }
      else if (chr === '>') {
        isTag = false;
      }
      else if (!isTag) {
        result += chr;
      }
    }
  }
  
  console.log(result);
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