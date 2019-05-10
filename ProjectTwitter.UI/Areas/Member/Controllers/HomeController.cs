using ProjectTwitter.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTwitter.UI.Areas.Member.Controllers
{
    public class HomeController : Controller
    {
        TweetService _tweetService;
        public HomeController()
        {
            _tweetService = new TweetService();
        }
        // GET: Member/Home
        public ActionResult Index()
        {
            var model = _tweetService.GetActive().OrderByDescending(x => x.CreatedDate).Take(10);
            return View(model);
        }
    }
}