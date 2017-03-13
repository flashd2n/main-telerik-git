'use strict';

let myGridItems = document.querySelector('.grid');

myGridItems.addEventListener('click', function (event) {

    if (event.target.tagName === 'IMG') {
        let elementToRemove = event.target.parentNode;

        let liCount = this.querySelectorAll('li').length;
                
        if (liCount > 1) {
            elementToRemove.parentNode.removeChild(elementToRemove);
        } else {
            let paragragh = this.previousElementSibling;
            paragragh.innerText = `The image you have picked is: ${event.target.alt}`;
        }

        // if (elementToRemove.parentNode.childElementCount > 1) {
        //     elementToRemove.parentNode.removeChild(elementToRemove);
        // } else {
        //     alert('this is the last image');
        // }

    }

    // elementToRemove.style.visibility = 'hidden';
}, false);