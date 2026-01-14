using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateNetwork.Models
{
    public class DayOffCalendar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DayOffCode { get; set; }

        public required DateTime OffDate { get; set; }

        public required int EmployeeID { get; set; }

        [MaxLength(500)]
        public required string Reason { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }
    }
}