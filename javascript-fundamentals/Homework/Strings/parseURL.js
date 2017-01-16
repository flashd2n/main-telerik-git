'use strict';

function solve(args) {
  let protocolSeparator = '://',
    serverSeparator = '/',
    input = args[0] + '',
    index = 0,
    len = protocolSeparator.length;

  let protocol = '',
      server = '', 
      resource = '';


  index = input.indexOf(protocolSeparator);
  protocol = input.substr(0, index);

  len = index + len;
  index = input.indexOf(serverSeparator, len);

  server = input.substr(len, index - len);
  resource = input.substr(index);

  console.log('protocol: ' + protocol);
  console.log('server: ' + server);
  console.log('resource: ' + resource);
}

solve([ 'http://telerikacademy.com/Courses/Courses/Details/212' ]);