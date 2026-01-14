using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("DepartmentCode")]
        public virtual required Department Department { get; set; }

        [ForeignKey("PersonalNumber")]
        public virtual required Employee Employee { get; set; }

        [ForeignKey("PositionCode")]
        public virtual required Position Position { get; set; }
    }
}