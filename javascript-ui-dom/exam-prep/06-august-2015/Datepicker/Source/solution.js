'use strict';

function solve() {
    $.fn.datepicker = function () {
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];
        var WEEK_DAY_NAMES_FULL = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

        Date.prototype.getMonthName = function () {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function () {
            return WEEK_DAY_NAMES[this.getDay()];
        };

        // you are welcome :)
        var date = new Date();
        // console.log(date.getDayName());
        // console.log(date.getMonthName());

        var $this = $(this);

        var wrapper = $('<div>').addClass('datepicker-wrapper');
        $this.addClass('datepicker').wrap(wrapper);
        wrapper = $this.parent();


        // need to remove the last class for toggle 
        var picker = $('<div>').addClass('datepicker-content').addClass('datepicker-content-visible');

        var controls = $('<div>').addClass('controls').appendTo(picker);
        var leftButton = $('<button>').addClass('btn btn-left').text('<').appendTo(controls);
        var selectedMonth = $('<div>').addClass('current-month').text(date.getMonthName() + ' ' + date.getFullYear()).appendTo(controls);
        var rightButton = $('<button>').addClass('btn btn-right').text('>').appendTo(controls);
        var currentDate = $('<div>').addClass('current-date').appendTo(picker);

        var currentDateLink = $('<a>').addClass('current-date-link')
            .attr('href', '#')
            .text(date.getDate() + ' ' + date.getMonthName() + ' ' + date.getFullYear())
            .appendTo(currentDate);

        var calendar = buildCalendar().appendTo(picker);



        function buildCalendar(date) {
            var calendar = $('<table>').addClass('calendar');

            var calendarRows = 6;
            var calendarCols = 7;

            var calendarHeader = $('<tr>').appendTo(calendar);

            for(var i = 0; i < calendarCols; i++){
                $('<th>').text(WEEK_DAY_NAMES[i]).appendTo(calendarHeader);
            }

            

            return calendar;
        }

        wrapper.append(picker);

        return $this;
    };
}