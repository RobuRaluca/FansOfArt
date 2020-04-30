using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication16.Models
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the Resource Name...")]
        [StringLength(50, MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Resource name ")]
        public string ResourceName { get; set; }

        [Required(ErrorMessage = "Please select the starting day of valability of the resource...")]
        [DataType(DataType.Date)]
        [Display(Name = "First day when reservation is available on the site to be be reserved")]
        public string StartDateReservation { get; set; }

        [Required(ErrorMessage = "Please select the end day of valability of the resource...")]
        [DataType(DataType.Date)]
        [Display(Name = "Last day when reservation is available on the site to be be reserved")]
        public string EndDateReservation { get; set; }
    }
}
