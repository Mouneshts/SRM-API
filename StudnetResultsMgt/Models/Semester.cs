using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SRM_API.Models
{
    [Table("Semester")]
    public class Semester
    {
        [Key]
        [Column("SemesterId")]
        public int SemesterId { get; set; }

        [Required]
        public string semester { get; set; }
        [Required]
        [Display(Name = "CourseId")]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Courses SCourses { get; set; }

    }
}
