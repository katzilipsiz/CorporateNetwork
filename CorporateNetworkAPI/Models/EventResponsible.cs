using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateNetwork.Models
{
    public class EventResponsible
    {
        [Key, Column(Order = 0)]
        public int EventCode { get; set; }

        [Key, Column(Order = 1)]
        public int EmployeeID { get; set; }

        [ForeignKey("EventCode")]
        public virtual required Event Event { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual required Employee Employee { get; set; }
    }
}