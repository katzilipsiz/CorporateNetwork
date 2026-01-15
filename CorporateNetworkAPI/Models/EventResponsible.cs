using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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
        [ValidateNever]
 public virtual Event Event { get; set; }

        [JsonIgnore]
        [ForeignKey("EmployeeID")]
        [ValidateNever]
 public virtual Employee Employee { get; set; }
    }
}