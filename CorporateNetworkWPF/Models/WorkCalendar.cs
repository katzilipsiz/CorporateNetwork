using System;

namespace CorporationNetworkWPF.Models
{
    public class WorkCalendar
    {
        public int DayCode { get; set; }
        public DateTime CalendarDate { get; set; }
        public bool IsWorkingDay { get; set; }
    }

    public class CreateWorkCalendarDto
    {
        public DateTime CalendarDate { get; set; }
        public bool IsWorkingDay { get; set; }
    }
}