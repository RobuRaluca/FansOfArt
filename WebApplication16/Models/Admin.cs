using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication16.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Required(ErrorMessage = "Please enter Admin Code...")]
        [Display(Name = "Admin Code")]
        [RegularExpression("[a-z]+[0-9]+[c-d]+[A-F]+[0-9]+[0-3]+[a-k]")]
        public string AdminCode { get; set; }


        [Required(ErrorMessage = "Please enter Username...")]
        [Display(Name = "Admin Name")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "Please enter Email...")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Admin Email")]
        public string AdminEmail { get; set; }

        [Required(ErrorMessage = "Please enter Password...")]
        [DataType(DataType.Password)]
        [Display(Name = "Admin Password")]
        public string AdminPassword { get; set; }

        [Required(ErrorMessage = "Please enter Confirm Password...")]
        [DataType(DataType.Password)]
        [Display(Name = "AdminConfirmPassword")]
        [Compare("AdminPassword")]
        public string AdminConfirmPassword { get; set; }
    }
}
