using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTwitter.UI.Models.VM
{
    public class SignUpVM
    {
        [Required(ErrorMessage = "Firstname Error!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lastname Error!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Username Error!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Error!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email Error!")]
        public string Email { get; set; }
    }
}