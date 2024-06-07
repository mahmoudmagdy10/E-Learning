using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.BL.Models
{
    public class RegisterVM
    {
        [EmailAddress(ErrorMessage = "Invalid Mail")]
        [Required(ErrorMessage = "This Field Is Required")]
        public string Email { get; set; }

        [MinLength(6, ErrorMessage = "Min Length Is 6")]
        [Required(ErrorMessage = "This Field Is Required")]
        public string Password { get; set; }

        [MinLength(6, ErrorMessage = "Min Length Is 6")]
        [Required(ErrorMessage = "This Field Is Required")]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        public string ConfirmPassword { get; set; }
    }
}
