using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalBlogWebSite.Models.EntitiesClass;

namespace PersonalBlogWebSite.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context ct = new Context();
        public ActionResult AboutMe()
        {
            var getData = ct.Abouts.ToList();
            return View(getData);
        }
    }
}