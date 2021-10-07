using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SRM_API.Models
{
    [Table("Subjects")]
    public class Subjects
    {
        [Key]
        [Column("SubjectId")]
       public int SubjectId { get; set; }

        [Required]
        [StringLength(100)]
        public string SubjectName { get; set; }

        public int Semid { get; set; }
        [ForeignKey("Semid")]
        public Semester semester{ get; set; }
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Courses Course { get; set; }


        //  [Display(Name = "bId")]
        public int bId { get; set; }

        [ForeignKey("bId")]
        public Branch subBraches { get; set; }

    }
}
