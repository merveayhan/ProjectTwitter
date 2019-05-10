using ProjectTwitter.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTwitter.UI.Areas.Member.Models.DTO
{
    public class TweetDTO
    {
        public Guid ID { get; set; }
        public string TweetContent { get; set; }
        public DateTime PublishDate { get; set; }

        public string ImagePath { get; set; }

        public string UserImage { get; set; }
        public string XSmallUserImage { get; set; }
        public string CruptedUserImage { get; set; }

        public Guid AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}