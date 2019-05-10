using ProjectTwitter.Model.Option;
using ProjectTwitter.UI.Areas.Member.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTwitter.UI.Areas.Member.Models.VM
{
    public class UpdateTweetVM
    {
        public UpdateTweetVM()
        {
            AppUsers = new List<AppUser>();          
            Tweet = new TweetDTO();
        }
     
        public List<AppUser> AppUsers { get; set; }
        public TweetDTO Tweet { get; set; }
    }
}