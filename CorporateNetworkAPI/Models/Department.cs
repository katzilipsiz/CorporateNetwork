using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("MainDepartment")]
        public virtual MainDepartment? MainDepartmentNavigation { get; set; }

        public virtual required ICollection<Employee> Employees { get; set; }
        public virtual required ICollection<DepartmentStructure> DepartmentStructures { get; set; }
        public virtual required ICollection<WorkSchedule> WorkSchedules { get; set; }
    }
}