namespace CorporationNetworkWPF.Models
{
    public class WorkSchedule
    {
        public int ScheduleCode { get; set; }
        public int DepartmentCode { get; set; }
        public int? TrainingCalendarCode { get; set; }
        public int WorkCalendarCode { get; set; }
    }

    public class CreateWorkScheduleDto
    {
        public int DepartmentCode { get; set; }
        public int? TrainingCalendarCode { get; set; }
        public int WorkCalendarCode { get; set; }
    }
}