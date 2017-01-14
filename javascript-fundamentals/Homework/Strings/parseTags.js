'use strict';

function solve(args) {
    let openUpper = 'upcase', closeUpper = '/upcase', openLower = 'lowcase', closeLower = '/lowcase', openOriginal = 'orgcase', originalClose = '/orgcase', upperScope = 'up', lowerScope = 'low', orgScope = 'initial';
    let CheckTag = false, scopeStack = [], currentScope = orgScope, currentTag = '', result = '';

    for (let i = 0; i < args[0].length; i++) {
        let c = args[0][i] + '';

        if (c === '<') {
            CheckTag = true;
        } else if (c === '>') {
            CheckTag = false;
            if (currentTag === openUpper) {
                scopeStack.push(currentScope);
                currentScope = upperScope;
            } else if (currentTag === openLower) {
                scopeStack.push(currentScope);
                currentScope = lowerScope;
            } else if (currentTag === openOriginal) {
                scopeStack.push(currentScope);
                currentScope = orgScope;
            } else if (currentTag === closeUpper) {
                currentScope = scopeStack.pop();
            } else if (currentTag === closeLower) {
                currentScope = scopeStack.pop();
            } else if (currentTag === originalClose) {
                currentScope = scopeStack.pop();
            } else {
                result += currentTag;
            }
            currentTag = '';
        } else if (CheckTag) {
            currentTag += c;
        } else if (!CheckTag) {
            if (currentScope === upperScope) {
                result += c.toUpperCase();
            } else if (currentScope === lowerScope) {
                result += c.toLowerCase();
            } else {
                result += c;
            }
        }
    }
    console.log(result);
}

solve([ 'We are <orgcase>liViNg</orgcase> in a <upcase>yellow su<bmarine</upcase>. We <orgcase>doN\'t</orgcase> have <lowcase>anything</lowcase> else.' ]);