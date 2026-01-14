using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorporateNetwork.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentCode { get; set; }

        public int? MainDepartment { get; set; }

        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [JsonIgnore]
        [ForeignKey("MainDepartment")]
        [ValidateNever]
 public virtual MainDepartment MainDepartmentNavigation { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<Employee> Employees { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<DepartmentStructure> DepartmentStructures { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<WorkSchedule> WorkSchedules { get; set; }
    }
}