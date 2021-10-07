using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SRM_MVC.Models
{
    public class Branch
    {
        [Required]
        public int BId { get; set; }
        [Required(ErrorMessage = "Enter Admin Name"), MaxLength(50)]
        [Display(Name = "Branch Name")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Course")]
        [Display(Name = "Course Name")]
        public int CourseId { get; set; }

        

    }
}
