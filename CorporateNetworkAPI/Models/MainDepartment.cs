using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorporateNetwork.Models
{
    public class MainDepartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MainDepartmentCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string MainDepartmentName { get; set; }

        [JsonIgnore]
        [ValidateNever]
        public virtual ICollection<Department> Departments { get; set; }
    }
}