using System;

namespace CorporationNetworkWPF.Models
{
    public class DayOffCalendar
    {
        public int DayOffCode { get; set; }
        public DateTime OffDate { get; set; }
        public int EmployeeID { get; set; }
        public string Reason { get; set; }
    }

    public class CreateDayOffCalendarDto
    {
        public DateTime OffDate { get; set; }
        public int EmployeeID { get; set; }
        public string Reason { get; set; }
    }
}