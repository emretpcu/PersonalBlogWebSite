using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalBlogWebSite.Models.EntitiesClass;

namespace PersonalBlogWebSite.Controllers
{
    public class HomeController : Controller
    {
        BlogDetailsModel bdm=new BlogDetailsModel();
        Context ct=new Context();
        public ActionResult HomePage()
        {
            bdm.ValueBlog=ct.Blogs.ToList();
            bdm.ValueBlog.ToList();
            return View(bdm);
        }
        public PartialViewResult PartialBlog()
        {
            bdm.LastBlog = ct.Blogs.OrderByDescending(i => i.Id).Take(2).ToList();
            bdm.FirstBlog = ct.Blogs.Where(i => i.Id==1).ToList();
            return PartialView(bdm);
        }
    }
}