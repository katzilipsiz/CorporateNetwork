using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public virtual required Material Material { get; set; }
        [JsonIgnore]
        [ForeignKey("EmployeeID")]
        public virtual required Employee Employee { get; set; }
    }
}