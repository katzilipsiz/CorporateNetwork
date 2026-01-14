using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public virtual required Department Department { get; set; }
        [JsonIgnore]
        [ForeignKey("PersonalNumber")]
        public virtual required Employee Employee { get; set; }
        [JsonIgnore]
        [ForeignKey("PositionCode")]
        public virtual required Position Position { get; set; }
    }
}