using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        [ForeignKey("DepartmentCode")]
        public virtual required Department Department { get; set; }
        [JsonIgnore]
        [ForeignKey("TrainingCalendarCode")]
        public virtual required TrainingCalendar TrainingCalendar { get; set; }
        [JsonIgnore]
        [ForeignKey("WorkCalendarCode")]
        public virtual required WorkCalendar WorkCalendar { get; set; }
    }
}