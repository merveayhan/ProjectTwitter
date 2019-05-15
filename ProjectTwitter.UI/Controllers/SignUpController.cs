using ProjectTwitter.Model.Option;
using ProjectTwitter.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTwitter.UI.Controllers
{
    public class SignUpController : Controller
    {
        AppUserService _appUserService;
        public SignUpController()
        {
            _appUserService = new AppUserService();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AppUser data)
        {
            
            _appUserService.Add(data);
            return Redirect("/Account/Login");
        }
    }
}