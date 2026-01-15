using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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
        [ValidateNever]
 public virtual Employee Employee { get; set; }

        [JsonIgnore]
        [ForeignKey("CandidateNumber")]
        [ValidateNever]
 public virtual Candidate Candidate { get; set; }
    }
}