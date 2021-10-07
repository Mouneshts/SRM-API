
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SRM_MVC.Models
{

    public class Student
    {
        
        public int StudentId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Confirmation Password is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }

        
        [DataType(DataType.EmailAddress),Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        public string StudentEmail { get; set; }



        [MaxLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public string PhoneNumber { get; set; }


        [StringLength(50)]
        [Required(ErrorMessage = "Enter Gender")]
        [Display(Name = "Gender")]
        public string StudentGender { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        public string StudentPassword { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("AdminPassword", ErrorMessage = "Password and Confirmation Password must match.")]
        [Display(Name = "Password")]
        [StringLength(255, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Course is required.")]
        [Display(Name = "Course")]
        public int Cid { get; set; }



        [Required(ErrorMessage = "Semester is required.")]
        [Display(Name = "Semester")]
        public int Semester { get; set; }


        [Required(ErrorMessage = "Branch is required.")]
        [Display(Name = "Branch")]
        public int BId { get; set; }

       
    }
}
