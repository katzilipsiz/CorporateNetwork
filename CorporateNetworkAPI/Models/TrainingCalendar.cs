using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateNetwork.Models
{
    public class TrainingCalendar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrainingCode { get; set; }
        public required DateTime TrainingDate { get; set; }
        public required int EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual required Employee Employee { get; set; }

        public virtual ICollection<TrainingMaterial> TrainingMaterials { get; set; }
        public virtual ICollection<WorkSchedule> WorkSchedules { get; set; }
    }
}