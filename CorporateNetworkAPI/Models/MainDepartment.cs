using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CorporateNetwork.Models
{
    public class MainDepartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MainDepartmentCode { get; set; }

        [MaxLength(100)]
        public required string MainDepartmentName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Department> Departments { get; set; }
    }
}