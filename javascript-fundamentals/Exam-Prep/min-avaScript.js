'use strict';

function solve(args){
    let numberOfLines = +args.length,
        insideSelector = false,
        globalPriority = 0,
        localPriority = globalPriority,
        superLocalPriority = localPriority;

    for(let i = 0; i < numberOfLines; i++){
        let line = args[i] + '';

        if(line.indexOf('{') >= 0){
            //start of selector
            insideSelector = true;


        } else if(line.indexOf('}') >= 0){
            // end of selector
            insideSelector = false;


        } else if(line.indexOf(':') >= 0){
            // binding line


        } else if(line.indexOf('@') >= 0){
            // priority line -- needs to check if in selector or not


        }



    }
}


solve([
    'li {',
    '    font-size: 2px;',
    '    font-weight: bold;',
    '}',
    'div {',
    '    font-size: 20px; @5',
    '}',
    'div { @4',
    '    font-size: 17px;',
    '}',
    '@19',
    'li {',
    '    font-size: 42px;',
    '    color: red; @9',
    '}'
]);