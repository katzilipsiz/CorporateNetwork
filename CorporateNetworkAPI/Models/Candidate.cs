using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace CorporateNetwork.Models
{
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string FullName { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(50)]
        public string? Passport { get; set; }

        [MaxLength(20)]
        public string? Snils { get; set; }

        [MaxLength(20)]
        public string? Inn { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        public string? AdditionalInfo { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<Interview> Interviews { get; set; }
    }
}