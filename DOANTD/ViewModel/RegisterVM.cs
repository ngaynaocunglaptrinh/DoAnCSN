using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DOANTD.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "no")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "nong")]
        public string Password { get; set; }

        [Required(ErrorMessage = "no")]
        [Compare("Password", ErrorMessage = "no")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "no")]
        [EmailAddress(ErrorMessage = "no")]
        public string Email { get; set; }

        public string Mobile { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
    }
}