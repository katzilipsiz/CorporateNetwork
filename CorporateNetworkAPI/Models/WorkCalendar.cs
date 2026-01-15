using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorporateNetwork.Models
{
    public class WorkCalendar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DayCode { get; set; }

        [Required]
        public DateTime CalendarDate { get; set; }

        [Required]
        public bool IsWorkingDay { get; set; } = true;

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<WorkSchedule> WorkSchedules { get; set; }
    }
}