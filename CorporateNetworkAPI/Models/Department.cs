using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CorporateNetwork.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentCode { get; set; }

        public int? MainDepartment { get; set; }

        [MaxLength(100)]
        public required string DepartmentName { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [JsonIgnore]
        [ForeignKey("MainDepartment")]
        public virtual MainDepartment? MainDepartmentNavigation { get; set; }
        [JsonIgnore]
        public virtual required ICollection<Employee> Employees { get; set; }
        [JsonIgnore]
        public virtual required ICollection<DepartmentStructure> DepartmentStructures { get; set; }
        [JsonIgnore]
        public virtual required ICollection<WorkSchedule> WorkSchedules { get; set; }
    }
}