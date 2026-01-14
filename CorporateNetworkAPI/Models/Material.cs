using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateNetwork.Models
{
    public class Material
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaterialCode { get; set; }

        [MaxLength(200)]
        public required string MaterialName { get; set; }

        public string? MaterialDescription { get; set; }

        public int? MaterialTypeCode { get; set; }

        [MaxLength(100)]
        public string? Area { get; set; }

        [MaxLength(50)]
        public string? Status { get; set; }

        [ForeignKey("MaterialTypeCode")]
        public virtual required MaterialType MaterialType { get; set; }

        public virtual ICollection<TrainingMaterial> TrainingMaterials { get; set; }
        public virtual ICollection<MaterialAuthor> MaterialAuthors { get; set; }
    }
}