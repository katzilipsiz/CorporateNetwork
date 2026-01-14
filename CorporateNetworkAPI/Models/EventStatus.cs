using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorporateNetwork.Models
{
    public class EventStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string StatusName { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<Event> Events { get; set; }
    }
}