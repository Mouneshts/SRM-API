using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SRM_MVC.Models
{
    [Table("Semester")]
    public class Semester
    {
      //  [Required(ErrorMessage = "Semester Id is required.")]
        [Column("SemesterId")]
        public int SemesterId { get; set; }

        [Required(ErrorMessage = "Semester is required.")]
        [Display(Name = "Semester")]
        public string semester { get; set; }
        [Required]
        [Display(Name = "Course Name")]
        public int CourseId { get; set; }

        

    }
}
