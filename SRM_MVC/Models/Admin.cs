
using System.ComponentModel.DataAnnotations;

namespace SRM_MVC.Models
{
    public class Admin
    {
        [Required]
        public int AdminId { get; set; }

        [Display(Name = "First Name"), StringLength(100)]
        [ Required(ErrorMessage = "Please Enter First Name..."), MaxLength(50), MinLength(4)]
        public string AdminFirstName { get; set; }

        [Display(Name = "Last Name")]
        [ Required(ErrorMessage = "Please Enter Last Name..."), MaxLength(50), MinLength(2), StringLength(100)]
        public string AdminLastName { get; set; }


        [Display(Name = "Email")]
        [RegularExpression("^[0-9a-zA-Z]+[.+-_]{0,4}[0-9a-zA-Z]+[@][a-zA-Z]+[.][a-zA-Z]{2,3}$",ErrorMessage="Please Valid Email Address")]
        [ Required(ErrorMessage = "Enter Email"), StringLength(100), EmailAddress]
        public string AdminEmail { get; set; }


        [Required(ErrorMessage = "Enter Gender"), MaxLength(7), MinLength(4)]
        [Display(Name = "Gender")]
        public string AdminGender { get; set; }

        [Display(Name = "City"), Required(ErrorMessage = "Please Enter City..."), MaxLength(50), MinLength(4), StringLength(50)]
        public string AdminCity { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password), Display(Name ="Password"), StringLength(255, MinimumLength = 5),MaxLength(50)]
        public string AdminPassword { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("AdminPassword", ErrorMessage = "Password and Confirmation Password must match.")]
        [Display(Name = "Confirm Password"),DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 5),MaxLength(50)]
        public string ConfirmPassword { get; set; }
    }
}
