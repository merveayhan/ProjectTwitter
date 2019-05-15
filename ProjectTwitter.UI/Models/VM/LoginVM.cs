﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTwitter.UI.Models.VM
{
    public class LoginVM
    { //gerekli olan
        [Required(ErrorMessage = "Username Error!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Error!")]
        public string Password { get; set; }
    }
}