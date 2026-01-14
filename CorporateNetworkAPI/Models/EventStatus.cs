using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateNetwork.Models
{
    public class EventStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusCode { get; set; }

        [MaxLength(50)]
        public required string StatusName { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}