(function () {
    webApp.namespace("webApp.page.dashboardManagement");
    webApp.page.dashboardManagement = (function () {
        return {
            options: {
                initialView: 'dayGridMonth',
                headerToolbar: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'dayGridMonth,timeGridWeek,timeGridDay'
                },
                events: [
                    {
                        title: "Record a video for Marisa",
                        start: "2022-10-03",
                    },
                ],
            },
            renderCalendar: function renderCalendarFn() {
                let calendarEl = document.getElementById('calendar');

                let calendar = new FullCalendar.Calendar(calendarEl, webApp.page.dashboardManagement.options);

                calendar.render();
            }
        }
    }());
}())

$(function () {  
    webApp.page.dashboardManagement.renderCalendar(); 
});