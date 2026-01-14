using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CorporateNetwork.Models
{
    public class TrainingCalendar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrainingCode { get; set; }
        public required DateTime TrainingDate { get; set; }
        public required int EmployeeID { get; set; }
        [JsonIgnore]
        [ForeignKey("EmployeeID")]
        public virtual required Employee Employee { get; set; }
        [JsonIgnore]
        public virtual ICollection<TrainingMaterial> TrainingMaterials { get; set; }
        [JsonIgnore]
        public virtual ICollection<WorkSchedule> WorkSchedules { get; set; }
    }
}