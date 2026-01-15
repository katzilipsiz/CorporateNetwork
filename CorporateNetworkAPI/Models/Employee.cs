using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorporateNetwork.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonalNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string FullName { get; set; }

        [Required]
        public int DepartmentCode { get; set; }

        [Required]
        public int PositionCode { get; set; }

        [MaxLength(20)]
        public string? WorkPhone { get; set; }

        [MaxLength(20)]
        public string? MobilePhone { get; set; }

        [MaxLength(10)]
        public string? OfficeNumber { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        public DateTime? BirthDate { get; set; }

        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; }

        public string? AdditionalInfo { get; set; }

        [JsonIgnore]
        [ForeignKey("DepartmentCode")]
        [ValidateNever]
 public virtual Department Department { get; set; }

        [JsonIgnore]
        [ForeignKey("PositionCode")]
        [ValidateNever]
 public virtual Position Position { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<DepartmentStructure> DepartmentStructures { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<Interview> Interviews { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<VacationCalendar> VacationCalendars { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<DayOffCalendar> DayOffCalendars { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<TrainingCalendar> TrainingCalendars { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<MaterialAuthor> MaterialAuthors { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<EventResponsible> EventResponsibles { get; set; }
    }
}