using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateNetwork.Models
{
    public class MaterialAuthor
    {
        [Key, Column(Order = 0)]
        public int MaterialCode { get; set; }

        [Key, Column(Order = 1)]
        public int EmployeeID { get; set; }

        [ForeignKey("MaterialCode")]
        public virtual required Material Material { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual required Employee Employee { get; set; }
    }
}