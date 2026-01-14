using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorporateNetwork.Models
{
    public class DepartmentStructure
    {
        [Key, Column(Order = 0)]
        public int DepartmentCode { get; set; }

        [Key, Column(Order = 1)]
        public int PersonalNumber { get; set; }

        [Key, Column(Order = 2)]
        public int PositionCode { get; set; }

        [JsonIgnore]
        [ForeignKey("DepartmentCode")]
        [ValidateNever]
 public virtual Department Department { get; set; }

        [JsonIgnore]
        [ForeignKey("PersonalNumber")]
        [ValidateNever]
 public virtual Employee Employee { get; set; }

        [JsonIgnore]
        [ForeignKey("PositionCode")]
        [ValidateNever]
 public virtual Position Position { get; set; }
    }
}