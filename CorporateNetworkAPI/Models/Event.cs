using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorporateNetwork.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventCode { get; set; }

        [Required]
        [MaxLength(200)]
        public string EventName { get; set; }

        [Required]
        public int StatusCode { get; set; }

        [Required]
        public int TypeCode { get; set; }

        [Required]
        public DateTime EventDateTime { get; set; }

        [MaxLength(500)]
        public string? ShortDescription { get; set; }

        [JsonIgnore]
        [ForeignKey("StatusCode")]
        [ValidateNever]
 public virtual EventStatus EventStatus { get; set; }

        [JsonIgnore]
        [ForeignKey("TypeCode")]
        [ValidateNever]
 public virtual EventType EventType { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<EventResponsible> EventResponsibles { get; set; }
    }
}