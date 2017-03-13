'use strict';

(function () {

    let myNode = document.querySelector('article#artlist ul.group');


    myNode.addEventListener('click', function (event) {
        if (event.target.tagName === 'IMG') {

            //initiate overlay
            let myOverlay = document.createElement('div');
            myOverlay.id = 'overlay';
            document.body.appendChild(myOverlay);

            //set up overlay styles
            myOverlay.style.position = 'absolute';
            myOverlay.style.backgroundColor = 'rgba(0,0,0,0.7)';
            myOverlay.style.cursor = 'pointer';

            //resize and position overlay
            myOverlay.style.width = window.innerWidth + 'px';
            myOverlay.style.height = window.innerHeight + 'px';
            myOverlay.style.top = window.pageYOffset + 'px';
            myOverlay.style.left = window.pageXOffset + 'px';

            //iniate image
            let originSrc = event.target.getAttribute('src');
            let highResImg = document.createElement('img');
            highResImg.id = 'largeImage';
            highResImg.src = originSrc.replace('_tn', '');
            highResImg.style.display = 'block';
            highResImg.style.position = 'absolute';

            //wait until image loads and resize and position
            highResImg.addEventListener('load', function (loadEvent) {

                if (this.height > window.innerHeight) {
                    this.height = window.innerHeight;
                } else if (this.width > window.innerWidth) {
                    this.width = window.innerWidth;
                }

                myOverlay.appendChild(highResImg);
                centerImage(this);

            }, false);

            //setup image close
            myOverlay.addEventListener('click', function (closeEvent) {
                window.removeEventListener('scroll', window, false);
                window.removeEventListener('resize', window, false);
                myOverlay.parentNode.removeChild(myOverlay);
            }, false);


            window.addEventListener('scroll', function () {

                if (myOverlay) {
                    myOverlay.style.top = window.pageYOffset + 'px';
                }

            }, false);

            window.addEventListener('resize', function () {

                if (myOverlay) {
                    myOverlay.style.width = window.innerWidth + 'px';
                    myOverlay.style.height = window.innerHeight + 'px';
                    myOverlay.style.top = window.pageYOffset + 'px';
                    myOverlay.style.left = window.pageXOffset + 'px';
                    centerImage(highResImg);
                }

            }, false);

        }
    }, false);

    function centerImage(image) {

        let heightDiff = window.innerHeight - image.height;
        let widthDiff = window.innerWidth - image.width;

        image.style.top = heightDiff / 2 + 'px';
        image.style.left = widthDiff / 2 + 'px';
    }
})();