using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public virtual required TrainingCalendar TrainingCalendar { get; set; }
        [JsonIgnore]
        [ForeignKey("MaterialCode")]
        public virtual required Material Material { get; set; }
    }
}