using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorporateNetwork.Models
{
    public class TrainingCalendar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrainingCode { get; set; }

        [Required]
        public DateTime TrainingDate { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [JsonIgnore]
        [ForeignKey("EmployeeID")]
        [ValidateNever]
 public virtual Employee Employee { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<TrainingMaterial> TrainingMaterials { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<WorkSchedule> WorkSchedules { get; set; }
    }
}