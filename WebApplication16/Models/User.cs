using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebApplication16.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        
        [Required(ErrorMessage ="Please enter Username...")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter Email...")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "UserEmail")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Please enter Password...")]
        [DataType(DataType.Password)]
        [Display(Name = "UserPassword")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Please enter Confirm Password...")]
        [DataType(DataType.Password)]
        [Display(Name = "UserConfirmPassword")]
        [Compare("UserPassword")]
        public string UserConfirmPassword { get; set; }
   
    }
}
