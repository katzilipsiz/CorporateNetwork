using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CorporateNetwork.Models
{
    public class MaterialType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeCode { get; set; }

        [MaxLength(100)]
        public required string TypeName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Material> Materials { get; set; }
    }
}