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

        [MaxLength(200)]
        public required string FullName { get; set; }

        [MaxLength(20)]
        public required string Phone { get; set; }

        [MaxLength(50)]
        public required string Passport { get; set; }

        [MaxLength(20)]
        public required string Snils { get; set; }

        [MaxLength(20)]
        public required string Inn { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        public string? AdditionalInfo { get; set; }

        [JsonIgnore]
        public virtual ICollection<Interview> Interviews { get; set; }
    }
}