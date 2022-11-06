using PersonalBlogWebSite.Models.EntitiesClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBlogWebSite.Controllers
{
    public class ContactController : Controller
    {
        Context ct = new Context();
        [HttpGet]
        public ActionResult ContactMe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactMe(Contact con)
        {
            var contactAdd = ct.Contacts.Add(con);
            ct.SaveChanges();
            ViewBag.Basarili = "Mesajınız bize başarılı şekilde ulaştı !! En kısa zamanda size mail yoluya dönüş yapacağız.";
            return View();
        }
    }
}