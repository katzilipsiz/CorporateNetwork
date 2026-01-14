using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CorporateNetwork.Models
{
    public class WorkCalendar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DayCode { get; set; }
        public required DateTime CalendarDate { get; set; }
        public required bool IsWorkingDay { get; set; } = true;
        [JsonIgnore]
        public virtual ICollection<WorkSchedule> WorkSchedules { get; set; }
    }
}