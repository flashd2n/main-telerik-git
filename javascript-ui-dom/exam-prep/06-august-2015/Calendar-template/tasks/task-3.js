'use strict';

// function solve() {
//     return function (selector) {
//         var template = `<div class="event-calendar">
//             <h2 class="header">Appointments for <span class="month">{{month}}</span> <span class="year">{{year}}</span></h2>
//             {{#each days}}
//             <div class="col-date">
//                 <div class="date">{{this.day}}</div>
//                 <div class="events">
//                     {{#each this.events}}
//                     {{#if this.title}}
//                     <div class="event {{this.importance}}" title="duration: {{this.duration}}">
//                         <div class="title">{{this.title}}</div>
//                         <span class="time">at: {{this.time}}</span>
//                     </div>
//                     {{else}}
//                     <div class="event none">
//                         <div class="title">Free slot</div>
//                     </div>
//                     {{/if}}
//                     {{/each}}
//                 </div>
//             </div>
//             {{/each}}
//         </div>`;



//         document.getElementById(selector).innerHTML = template;
//     };
// }



function solve() {
    return function(selector) {
        var template = `<div class="events-calendar">
            <h2 class="header">
                Appointments for <span class="month">{{month}}</span> <span class="year">{{year}}</span>
            </h2>
            {{#each days}}
            <div class="col-date">
                <div class="date">{{day}}</div>
                {{#if events.length}}
                <div class="events">
                    {{#each events}} {{#if title.length}}
                    <div class="event {{this.importance}}" title="duration: {{this.duration}}">
                        <div class="title">{{title}}</div>
                        <span class="time">at: {{this.time}}</span>
                    </div>
                    {{else}}
                    <div class="event {{this.importance}}">
                        <div class="title">Free slot</div>
                    </div>
                    {{/if}} {{/each}}
                </div>
                {{/if}}
            </div>
            {{/each}}
        </div>`;
        document.getElementById(selector).innerHTML = template;
    };
}

module.exports = solve;