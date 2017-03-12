'use strict';

document.querySelector('img.preview').addEventListener('click', function(event){

    let lowResSrc = this.src;
    let overlay = document.querySelector('.overlay');
    let highRes = document.createElement('img');
    let spinner = document.createElement('img');

    overlay.style.display = 'block';
    highRes.className = 'bgImg';
    highRes.src = lowResSrc.replace('_tn', '');
    overlay.appendChild(highRes);

    spinner.className = 'spinner';
    spinner.src = '/images/spinner.gif';
    overlay.appendChild(spinner);

    highRes.addEventListener('load', function(){

        spinner.parentNode.removeChild(spinner);

    }, false);

}, false);
