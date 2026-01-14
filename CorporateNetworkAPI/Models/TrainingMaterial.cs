using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateNetwork.Models
{
    public class TrainingMaterial
    {
        [Key, Column(Order = 0)]
        public int TrainingCode { get; set; }

        [Key, Column(Order = 1)]
        public int MaterialCode { get; set; }

        [ForeignKey("TrainingCode")]
        public virtual required TrainingCalendar TrainingCalendar { get; set; }

        [ForeignKey("MaterialCode")]
        public virtual required Material Material { get; set; }
    }
}