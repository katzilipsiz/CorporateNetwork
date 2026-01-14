using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public virtual required ICollection<Employee> Employees { get; set; }
        public virtual required ICollection<DepartmentStructure> DepartmentStructures { get; set; }
    }
}