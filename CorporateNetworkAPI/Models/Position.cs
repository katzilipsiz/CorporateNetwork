using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorporateNetwork.Models
{
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PositionCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string PositionName { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<Employee> Employees { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<DepartmentStructure> DepartmentStructures { get; set; }
    }
}