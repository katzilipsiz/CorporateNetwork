using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorporateNetwork.Models
{
    public class Material
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaterialCode { get; set; }

        [Required]
        [MaxLength(200)]
        public string MaterialName { get; set; }

        public string? MaterialDescription { get; set; }

        public int? MaterialTypeCode { get; set; }

        [MaxLength(100)]
        public string? Area { get; set; }

        [MaxLength(50)]
        public string? Status { get; set; }

        [JsonIgnore]
        [ForeignKey("MaterialTypeCode")]
        [ValidateNever]
 public virtual MaterialType MaterialType { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<TrainingMaterial> TrainingMaterials { get; set; }

        [JsonIgnore]
        [ValidateNever]
 public virtual ICollection<MaterialAuthor> MaterialAuthors { get; set; }
    }
}