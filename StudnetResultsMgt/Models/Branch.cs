using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SRM_API.Models
{
    public class Branch
    {
        [Key]
        public int BId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        [Display(Name = "CourseId")]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Courses BCourses { get; set; }
    }
}
