using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CorporateNetwork.Models
{
    public class EventResponsible
    {
        [Key, Column(Order = 0)]
        public int EventCode { get; set; }

        [Key, Column(Order = 1)]
        public int EmployeeID { get; set; }
        [JsonIgnore]
        [ForeignKey("EventCode")]
        public virtual required Event Event { get; set; }
        [JsonIgnore]
        [ForeignKey("EmployeeID")]
        public virtual required Employee Employee { get; set; }
    }
}