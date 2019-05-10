using ProjectTwitter.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTwitter.UI.Areas.Member.Models.VM
{
    public class AddTweetVM
    {
        public AddTweetVM()
        {         
            AppUsers = new List<AppUser>();
        }
        public List<AppUser> AppUsers { get; set; }
        
    }
}