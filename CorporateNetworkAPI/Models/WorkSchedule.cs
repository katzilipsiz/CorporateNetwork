using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorporateNetwork.Models
{
    public class WorkSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleCode { get; set; }

        [Required]
        public int DepartmentCode { get; set; }

        public int? TrainingCalendarCode { get; set; }

        [Required]
        public int WorkCalendarCode { get; set; }

        [JsonIgnore]
        [ForeignKey("DepartmentCode")]
        [ValidateNever]
 public virtual Department Department { get; set; }

        [JsonIgnore]
        [ForeignKey("TrainingCalendarCode")]
        [ValidateNever]
 public virtual TrainingCalendar TrainingCalendar { get; set; }

        [JsonIgnore]
        [ForeignKey("WorkCalendarCode")]
        [ValidateNever]
 public virtual WorkCalendar WorkCalendar { get; set; }
    }
}