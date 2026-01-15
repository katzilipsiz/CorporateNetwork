using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorporateNetwork.Models
{
    public class DayOffCalendar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DayOffCode { get; set; }

        [Required]
        public DateTime OffDate { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(500)]
        public string Reason { get; set; }

        [JsonIgnore]
        [ForeignKey("EmployeeID")]
        [ValidateNever]
 public virtual Employee Employee { get; set; }
    }
}