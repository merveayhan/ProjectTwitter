using ProjectTwitter.Model.Option;
using ProjectTwitter.Service.Option;
using ProjectTwitter.UI.Areas.Member.Models.DTO;
using ProjectTwitter.UI.Areas.Member.Models.VM;
using ProjectTwitter.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ProjectTwitter.UI.Areas.Member.Controllers
{
    public class TweetController : Controller
    {
       
        
        AppUserService _appUserService;
        TweetService _tweetService;

        public TweetController()
        {
           
            _appUserService = new AppUserService();
            _tweetService = new TweetService();
        }
        public ActionResult Add()
        {
            AddTweetVM model = new AddTweetVM()
            {
                AppUsers = _appUserService.GetActive(),
              
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(Tweet data)
        {
            //List<string> UploadedImagePaths = new List<string>();

            //UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            //data.ImagePath = UploadedImagePaths[0];

            //if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            //{
            //    data.ImagePath = ImageUploader.DefaultProfileImagePath;
            //    data.ImagePath = ImageUploader.DefaultXSmallProfileImage;
            //    data.ImagePath = ImageUploader.DefaulCruptedProfileImage;
            //}
            //else
            //{
            //    data.ImagePath = UploadedImagePaths[1];
            //    data.ImagePath = UploadedImagePaths[2];
            //}

            //AppUser user = _appUserService.GetByDefault(x => x.UserName == User.Identity.Name);
            //data.AppUserID = user.ID;
            //data.PublishDate = DateTime.Now;

            _tweetService.Add(data);
            return Redirect("/Member/Home/Index");
        }
        public ActionResult List()
        {
            Guid userID = _appUserService.FindByUserName(User.Identity.Name).ID;
            List<Tweet> model = _tweetService.GetDefault(x => x.AppUserID == userID && (x.Status == Core.Enum.Status.Active || x.Status == Core.Enum.Status.Updated));
            return View(model);
        }
        public ActionResult Update(Guid id)
        {
            Tweet tweet = _tweetService.GetByID(id);
            UpdateTweetVM model = new UpdateTweetVM();
            model.Tweet.ID = tweet.ID;
            model.Tweet.TweetContent = tweet.TweetContent;          
            model.Tweet.PublishDate = DateTime.Now;
            model.Tweet.ImagePath = tweet.ImagePath;
            List<AppUser> appusermodel = _appUserService.GetActive();
            model.AppUsers = appusermodel;
            
            return View(model);

        }
        [HttpPost]
        public ActionResult Update(TweetDTO data, HttpPostedFileBase Image)
        {
            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.ImagePath = UploadedImagePaths[0];

            Tweet update = _tweetService.GetByID(data.ID);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {

                if (update.ImagePath == null || update.ImagePath == ImageUploader.DefaultProfileImagePath)
                {
                    update.ImagePath = ImageUploader.DefaultProfileImagePath;
                    update.ImagePath = ImageUploader.DefaultXSmallProfileImage;
                    update.ImagePath = ImageUploader.DefaulCruptedProfileImage;
                }
                else
                {
                    update.ImagePath = update.ImagePath;
                }

            }
            else
            {
                update.ImagePath = UploadedImagePaths[0];
                update.ImagePath = UploadedImagePaths[1];
                update.ImagePath = UploadedImagePaths[2];
            }

            Tweet tweet = _tweetService.GetByID(data.ID);
            tweet.TweetContent = data.TweetContent;
            tweet.PublishDate = data.PublishDate;
           
            tweet.AppUserID = data.AppUserID;
            tweet.Status = Core.Enum.Status.Updated;
            _tweetService.Update(tweet);
            return Redirect("/Member/Home/Index");
        }
        public ActionResult Delete(Guid id)
        {
            _tweetService.Remove(id);
            return Redirect("/Member/Home/Index");
        }
    }
}