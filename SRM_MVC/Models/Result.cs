using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SRM_MVC.Models
{
   
    public  class Result
    {
        public int ResultId { get; set; }

        [Required(ErrorMessage = "Semester is required.")]
        [Display(Name = "Semester Name")]
        public int SemesterId { get; set; }


        [Required(ErrorMessage = "Student is required.")]
        [Display(Name = "Student Name")]
        public int SId { get; set; }
        [Required(ErrorMessage = "Subject is required.")]
        [Display(Name = "Subject Name")]
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "Result Score is required.")]
        [StringLength(100)]
        [Display(Name = "Result Score")]
        public string ResultScore { get; set; }

        [Required(ErrorMessage = "Result Status is required.")]
        [StringLength(100)]
        [Display(Name = "Result Status")]
        public string ResultStatus { get; set; }




    }
}
