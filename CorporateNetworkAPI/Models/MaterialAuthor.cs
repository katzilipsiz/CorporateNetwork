using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorporateNetwork.Models
{
    public class MaterialAuthor
    {
        [Key, Column(Order = 0)]
        public int MaterialCode { get; set; }

        [Key, Column(Order = 1)]
        public int EmployeeID { get; set; }

        [JsonIgnore]
        [ForeignKey("MaterialCode")]
        [ValidateNever]
 public virtual Material Material { get; set; }

        [JsonIgnore]
        [ForeignKey("EmployeeID")]
        [ValidateNever]
 public virtual Employee Employee { get; set; }
    }
}