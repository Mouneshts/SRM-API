using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SRM_API.Models
{
    [Table("Result")]
    public  class Result
    {
        [Key]
        [Column("ResultId")]
        public int ResultId { get; set; }

        [Required]
        [Display(Name = "SemesterId")]
        public int SemesterId { get; set; }

        [ForeignKey("SemesterId")]
        public Semester Rsemester{ get; set; }


        [Required]
        [Display(Name = "StudentId")]
        public int SId { get; set; }

        [ForeignKey("SId")]
        public Student Rstudents { get; set; }

        [Required]
        [Display(Name = "SubjectId")]
        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public Subjects Rsubjects { get; set; }

        [Required]
        [StringLength(100)]
        public string ResultScore { get; set; }

        [Required]
        [StringLength(100)]
        public string ResultStatus { get; set; }


    }
}
