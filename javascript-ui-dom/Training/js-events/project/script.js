'use strict';

let dragndrop = (function () {

    let myX = '',
        myY = '',
        whichArt = '';

    function resetZ(){
        let images = document.querySelector('img');

        for(let i = 0; i < images.length; i++){
            images[i].style.zIndex = 5;
        }
    }

    function moveStart(event) {
        whichArt = event.target;
        myX = event.offsetX === undefined ? event.layerX : event.offsetX;
        myX = event.offsetY === undefined ? event.layerY : event.offsetY;
        resetZ();
        whichArt.style.zIndex = 10;
    }

    function moveDrop(event) {
        event.preventDefault();
        whichArt.style.left = event.pageX - myX + 'px';
        whichArt.style.top = event.pageY - myY + 'px';
    }

    function moveDragOver(event) {

        event.preventDefault();

    }

    document.body.addEventListener('dragstart', moveStart, false);
    document.body.addEventListener('dragover', moveDragOver, false);
    document.body.addEventListener('drop', moveDrop, false);

})();