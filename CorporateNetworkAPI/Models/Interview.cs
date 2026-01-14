using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CorporateNetwork.Models
{
    public class Interview
    {
        [Key, Column(Order = 0)]
        public int EmployeeID { get; set; }

        [Key, Column(Order = 1)]
        public DateTime InterviewDateTime { get; set; }

        public int CandidateNumber { get; set; }
        [JsonIgnore]
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }
        [JsonIgnore]
        [ForeignKey("CandidateNumber")]
        public virtual Candidate Candidate { get; set; }
    }
}