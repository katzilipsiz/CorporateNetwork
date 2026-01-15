using System;

namespace CorporationNetworkWPF.Models
{
    public class VacationCalendar
    {
        public int VacationCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployeeID { get; set; }
    }

    public class CreateVacationCalendarDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployeeID { get; set; }
    }
}