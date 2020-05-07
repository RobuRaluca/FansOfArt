using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication16.Models
{
    public class AddNewPayment2
    {

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter Contribution Name...")]
        [Display(Name = "Contribution Name")]
        public string ContributionName { get; set; }

        [Required(ErrorMessage = "Please enter Contribution Privilege...")]
        [Display(Name = "Contribution Privilege")]
        public string ContributionPrivilege { get; set; }


        [Required(ErrorMessage = "Please enter Contribution Description...")]
        [Display(Name = "Contribution Description")]
        public string ContributionDescription { get; set; }


        [Display(Name = "Contribution User Status")]
        public string UserStatus { get; set; }
    }


}
