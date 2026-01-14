using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateNetwork.Models
{
    public class MaterialType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeCode { get; set; }

        [MaxLength(100)]
        public required string TypeName { get; set; }

        public virtual ICollection<Material> Materials { get; set; }
    }
}