using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SRM_MVC.Models
{
    
    public class Courses
    {
        [Required]
        [Column("CourseId")]
        [Display(Name = "Course Name")]

        public int CourseId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }


    }
}
