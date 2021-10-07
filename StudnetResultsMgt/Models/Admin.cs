using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRM_API.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        [Column("AdminId")]
        
        public int AdminId { get; set; }

        [Required]
        [StringLength(100)]
        public string AdminFirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string AdminLastName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string AdminEmail { get; set; }
        

        [StringLength(50)]
        public string AdminGender { get; set; }

        [StringLength(50)]
        public string AdminCity { get; set; }

        
        [StringLength(255,MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }



    }
}
