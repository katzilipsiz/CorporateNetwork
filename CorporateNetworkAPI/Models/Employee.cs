using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CorporateNetwork.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonalNumber { get; set; }

        [MaxLength(200)]
        public required string FullName { get; set; }

        public required int DepartmentCode { get; set; }

        public required int PositionCode { get; set; }

        [MaxLength(20)]
        public string? WorkPhone { get; set; }

        [MaxLength(20)]
        public string? MobilePhone { get; set; }

        [MaxLength(10)]
        public string? OfficeNumber { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        public DateTime? BirthDate { get; set; }

        [MaxLength(255)]
        public required string PasswordHash { get; set; }

        public string? AdditionalInfo { get; set; }

        [JsonIgnore]
        [ForeignKey("DepartmentCode")]
        public virtual required Department Department { get; set; }
        [JsonIgnore]
        [ForeignKey("PositionCode")]
        public virtual required Position Position { get; set; }
        [JsonIgnore]
        public virtual ICollection<DepartmentStructure> DepartmentStructures { get; set; }
        [JsonIgnore]
        public virtual ICollection<Interview> Interviews { get; set; }
        [JsonIgnore]
        public virtual ICollection<VacationCalendar> VacationCalendars { get; set; }
        [JsonIgnore]
        public virtual ICollection<DayOffCalendar> DayOffCalendars { get; set; }
        [JsonIgnore]
        public virtual ICollection<TrainingCalendar> TrainingCalendars { get; set; }
        [JsonIgnore]
        public virtual ICollection<MaterialAuthor> MaterialAuthors { get; set; }
        [JsonIgnore]
        public virtual ICollection<EventResponsible> EventResponsibles { get; set; }
    }
}