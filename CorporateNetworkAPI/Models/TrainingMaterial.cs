using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorporateNetwork.Models
{
    public class TrainingMaterial
    {
        [Key, Column(Order = 0)]
        public int TrainingCode { get; set; }

        [Key, Column(Order = 1)]
        public int MaterialCode { get; set; }

        [JsonIgnore]
        [ForeignKey("TrainingCode")]
        [ValidateNever]
 public virtual TrainingCalendar TrainingCalendar { get; set; }

        [JsonIgnore]
        [ForeignKey("MaterialCode")]
        [ValidateNever]
 public virtual Material Material { get; set; }
    }
}