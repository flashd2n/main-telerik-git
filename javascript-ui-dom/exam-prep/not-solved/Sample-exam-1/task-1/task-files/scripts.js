'use strict';

function createCalendar(selector, events) {

    var days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat']

    var container = document.querySelector(selector);

    var fullDate = new Date(2014, 5, 1);

    for (var i = 0; i < 30; i++) {

        var day = days[fullDate.getDay() + (i % 7)];
        var date = fullDate.getDate() + i;
        var month = 'June';
        var year = fullDate.getFullYear();
        var headerContent = day + ' ' + date + ' ' + month + ' ' + year;

        var newLine = false;

        if (i % 7 === 0) {
            newLine = true;
        }

        generateCell(headerContent, newLine, (i + 1));
    }

    var content = '';
    var allCells = document.getElementsByClassName('cell');

    events.forEach(function (event) {

        var spanOne = document.createElement('span');
        spanOne.className = 'eventHour';
        spanOne.innerHTML = event.hour;

        var spanTwo = document.createElement('span');
        spanTwo.className = 'eventTitle';
        spanTwo.style.fontWeight = 'bold';
        spanTwo.innerHTML = ' ' + event.title;
        
        var cellsLength = allCells.length;
        for(var i = 0; i < cellsLength; i++){

            if(allCells[i].getAttribute('data-date') === event.date){
                allCells[i].children[1].appendChild(spanOne);
                allCells[i].children[1].appendChild(spanTwo);
                break;
            }
        }

    });


    var hasSelected = false;
    container.addEventListener('click', function (event) {

        var target = event.target;

        if (target.className === 'cellBody' || target.className === 'cellHeader') {

            var wholeCell = target.parentNode;

            if (wholeCell.style.backgroundColor === 'green') {
                wholeCell.style.backgroundColor = '';
                hasSelected = false;
            } else if (!hasSelected) {
                wholeCell.style.backgroundColor = 'green';
                hasSelected = true;
            }
        }

    }, false);

    container.addEventListener('mouseover', function (event) {
        event.stopPropagation();
        var target = event.target;

        if (target.className === 'cellBody' || target.className === 'cellHeader') {
            var wholeCell = target.parentNode;
            var header = wholeCell.children[0];

            header.style.backgroundColor = 'yellow';

        }

    }, false);

    container.addEventListener('mouseout', function (event) {
        event.stopPropagation();
        var target = event.target;

        if (target.className === 'cellBody' || target.className === 'cellHeader') {
            var wholeCell = target.parentNode;
            var header = wholeCell.children[0];

            header.style.backgroundColor = 'lightgrey';

        }

    }, false);



    function generateCell(headerContent, newLine, index) {
        var cell = document.createElement('div');
        cell.className = 'cell';
        cell.setAttribute('data-date', index);
        cell.style.width = '150px';
        cell.style.height = '150px';
        cell.style.border = '1px solid black';
        cell.style.cssFloat = 'left';
        if (newLine) {
            cell.style.clear = 'both';
        }

        var cellHeader = document.createElement('div');
        cellHeader.className = 'cellHeader';
        cellHeader.style.backgroundColor = 'lightgrey';
        cellHeader.style.fontWeight = 'bold';
        cellHeader.style.textAlign = 'center';
        cellHeader.style.borderBottom = '1px solid black';
        cellHeader.innerHTML = headerContent;
        cell.appendChild(cellHeader);

        var cellBody = document.createElement('div');
        cellBody.className = 'cellBody';
        cellBody.style.width = '100%';
        cellBody.style.height = '100%';
        cell.appendChild(cellBody);

        container.appendChild(cell);
    }

}