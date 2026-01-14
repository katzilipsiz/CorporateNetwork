using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CorporateNetwork.Models
{
    public class EventStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusCode { get; set; }

        [MaxLength(50)]
        public required string StatusName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Event> Events { get; set; }
    }
}