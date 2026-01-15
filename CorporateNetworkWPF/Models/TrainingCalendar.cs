using System;

namespace CorporationNetworkWPF.Models
{
    public class TrainingCalendar
    {
        public int TrainingCode { get; set; }
        public DateTime TrainingDate { get; set; }
        public int EmployeeID { get; set; }
    }

    public class CreateTrainingCalendarDto
    {
        public DateTime TrainingDate { get; set; }
        public int EmployeeID { get; set; }
    }
}