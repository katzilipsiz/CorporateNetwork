using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateNetwork.Models
{
    public class WorkSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleCode { get; set; }

        public required int DepartmentCode { get; set; }

        public int? TrainingCalendarCode { get; set; }

        public required int WorkCalendarCode { get; set; }

        [ForeignKey("DepartmentCode")]
        public virtual required Department Department { get; set; }

        [ForeignKey("TrainingCalendarCode")]
        public virtual required TrainingCalendar TrainingCalendar { get; set; }

        [ForeignKey("WorkCalendarCode")]
        public virtual required WorkCalendar WorkCalendar { get; set; }
    }
}