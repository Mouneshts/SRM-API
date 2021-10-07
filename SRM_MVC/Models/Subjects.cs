using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SRM_MVC.Models
{
    
    public class Subjects
    {
       [Required]
        public int SubjectId { get; set; }

       // [Required(ErrorMessage = "Subject is Empty"), MaxLength(50)]
        [Display(Name = "Subject Name")]
        [StringLength(100)]
        public string SubjectName { get; set; }

       // [Required(ErrorMessage = "Semester is Empty"), MaxLength(50)]
        [Display(Name = "Semester ")]
        public int Semid { get; set; }

        //[Required(ErrorMessage = "Course is Empty"), MaxLength(50)]
        [Display(Name = "Course ")]
        public int CourseId { get; set; }

         [Display(Name = "Branch")]
        public int bId { get; set; }



    }
}
