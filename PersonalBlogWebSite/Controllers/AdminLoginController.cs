using PersonalBlogWebSite.Models.EntitiesClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonalBlogWebSite.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        Context ct = new Context();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login log)
        {
            var checkAccount = ct.Logins.FirstOrDefault(i => i.Username == log.Username && i.Password == log.Password);
            if (checkAccount!=null)
            {
                FormsAuthentication.SetAuthCookie(checkAccount.Username, false);
                Session["Username"] = checkAccount.Username.ToString();
                return RedirectToAction("AdminBlogList", "Admin");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("HomePage", "Home");
        }
    }
}