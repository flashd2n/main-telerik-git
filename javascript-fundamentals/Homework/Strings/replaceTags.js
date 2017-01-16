'use strict';

function solve(args) {
    let text = args[0] + '';
    let result = '';
        
        let openTag = "<a href=";
        let endTag = "</a>";

        let startIndexOpenTag = text.indexOf(openTag);
        let indexCloseTag = text.indexOf(endTag);
        let indexCurrPart = 0;

        while (startIndexOpenTag !== -1 || indexCloseTag !== -1)
        {
            let currPart = text.substr(indexCurrPart, startIndexOpenTag - indexCurrPart);  // takes the text BEFORE the opening of the anchor    
            let toEdit = text.substr(startIndexOpenTag, indexCloseTag - startIndexOpenTag + endTag.length); // takes the FULL anchor tag
            let urll = "(" + toEdit.substr(openTag.length + 1, (toEdit.indexOf(">") - openTag.length - 1 - 1)) + ")"; // formats the final url
            let innerText = "[" + toEdit.substr(toEdit.indexOf(">") + 1, toEdit.lastIndexOf("<") - toEdit.indexOf(">") - 1) + "]"; // formats the message inside the URL

            result += currPart;   //result.Replace(toEdit, innerText + url); //timelimit for every test
            result += innerText;
            result += urll;
            



            indexCurrPart = indexCloseTag + endTag.length;            
            startIndexOpenTag = text.indexOf(openTag, startIndexOpenTag + 1);
            indexCloseTag = text.indexOf(endTag, indexCloseTag + 1);

            if (startIndexOpenTag === -1 && indexCloseTag === -1)
            {
                currPart = text.substr(indexCurrPart);
                result += currPart;
            }
        }

        console.log(result);
}


solve([
    '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>'
]);