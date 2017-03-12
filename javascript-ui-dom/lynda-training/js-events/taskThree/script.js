'use strict';

let myGrid = document.querySelector('.grid');

// // mouseover to zoom event

// myGrid.addEventListener('mouseover', function (event) {

//   if (event.target.tagName === 'IMG') {

//     let myElement = document.createElement('div');
//     myElement.className = 'preview';
//     event.target.parentNode.appendChild(myElement);

//     let myImg = document.createElement('img');
//     let imgLocation = event.target.src;
//     myImg.src = imgLocation.replace('_tn', '');
//     myElement.appendChild(myImg);

//     event.target.addEventListener('mouseout', function handler(imgEvent){

//       let elementToRemove = this.nextElementSibling;
//       elementToRemove.parentNode.removeChild(elementToRemove);
//       this.removeEventListener('mouseout', handler, false);

//     }, false);
//   }
// }, false);


myGrid.addEventListener('contextmenu', function (event) {

  if (event.target.tagName === 'IMG') {

    event.preventDefault();

    let myElement = document.createElement('div');
    myElement.className = 'preview';
    event.target.parentNode.appendChild(myElement);

    myElement.style.left = event.offsetX + 15 + 'px';
    myElement.style.top = event.offsetY + 15 + 'px';

    let myImg = document.createElement('img');
    let imgLocation = event.target.src;
    myImg.src = imgLocation.replace('_tn', '');
    myElement.appendChild(myImg);

   event.target.addEventListener('mousemove', function(mouseMoveEvent){
    myElement.style.left = mouseMoveEvent.offsetX + 15 + 'px';
    myElement.style.top = mouseMoveEvent.offsetY + 15 + 'px';

   }, false);
   
    event.target.addEventListener('mouseout', function handler(imgEvent){
      let elementToRemove = this.nextElementSibling;
      elementToRemove.parentNode.removeChild(elementToRemove);
      this.removeEventListener('mouseout', handler, false);
    }, false);
  }
}, false);