using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateNetwork.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventCode { get; set; }

        [MaxLength(200)]
        public required string EventName { get; set; }
        public required int StatusCode { get; set; }
        public required int TypeCode { get; set; }
        public required DateTime EventDateTime { get; set; }

        [MaxLength(500)]
        public string ShortDescription { get; set; }

        [ForeignKey("StatusCode")]
        public virtual required EventStatus EventStatus { get; set; }
        [ForeignKey("TypeCode")]
        public virtual required EventType EventType { get; set; }

        public virtual ICollection<EventResponsible> EventResponsibles { get; set; }
    }
}