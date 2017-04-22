'use strict'

var request;
if (window.XMLHttpRequest) {
    request = new XMLHttpRequest();
} else {
    request = new ActiveXObject("Microsoft.XMLHTTP");
}

request.open('GET', 'data.json');
request.onreadystatechange = function () {
    if ((request.status === 200) &&
        (request.readyState === 4)) {

        var info = JSON.parse(request.responseText);

        var output = '';
        for (var i = 0; i <= info.links.length - 1; i++) {
            for (let key in info.links[i]) {
                if (info.links[i].hasOwnProperty(key)) {
                    output += '<li>' +
                        '<a href = "' + info.links[i][key] +
                        '">' + key + '</a>';
                    '</li>';
                }
            }
        }

        var update = document.getElementById('links');
        update.innerHTML = output;


    } //ready
} //event
request.send();
