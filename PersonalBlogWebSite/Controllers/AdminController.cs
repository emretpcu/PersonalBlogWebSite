using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalBlogWebSite.Models.EntitiesClass;
using System.IO;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using PagedList.Mvc;
using PagedList;

namespace PersonalBlogWebSite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context ct = new Context();
        [Authorize]
        public ActionResult AdminBlogList()
        {
            var getBlog = ct.Blogs.ToList();
            return View(getBlog);
        }
        [Authorize]
        public ActionResult DeleteBlog(int id)
        {
            var findId = ct.Blogs.Find(id);
            ct.Blogs.Remove(findId);
            ct.SaveChanges();
            return RedirectToAction("AdminBlogList", "Admin");
        }
        [HttpGet]
        [Authorize]
        public ActionResult UpdateBlog(int id)
        {
            var getBlog = ct.Blogs.Find(id);
            return View(getBlog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog bg, HttpPostedFileBase postedFile)
        {
            var updateBlog = ct.Blogs.Find(bg.Id);
            updateBlog.BlogTitle = bg.BlogTitle;
            updateBlog.BlogExplanation = bg.BlogExplanation;

            if (postedFile != null)
            {
                string path = Server.MapPath("~/Images/BlogImages/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
                updateBlog.BlogImage = "/Images/BlogImages/" + Path.GetFileName(postedFile.FileName);
                ViewBag.Message = "File uploaded successfully.";
            }
            else
            {
                updateBlog.BlogImage = bg.BlogImage;
            }
            ct.SaveChanges();

            return RedirectToAction("AdminBlogList", "Admin");
        }
        [HttpGet]
        [Authorize]
        public ActionResult AdminAbout()
        {
            var getAboutList = ct.Abouts.Find(1);
            return View(getAboutList);
        }
        [HttpPost]
        public ActionResult AdminAbout(About ab, HttpPostedFileBase postedFile)
        {
            var getAbout = ct.Abouts.Find(1);
            getAbout.AboutExplanation = ab.AboutExplanation;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Images/AboutImages/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
                getAbout.AboutImage = "/Images/AboutImages/" + Path.GetFileName(postedFile.FileName);
                ViewBag.Message = "File uploaded successfully.";
            }
            else
            {
                getAbout.AboutImage = ab.AboutImage;
            }
            ct.SaveChanges();
            return RedirectToAction("AboutMe", "About");
        }
        [HttpGet]
        [Authorize]
        public ActionResult RegisterBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterBlog(Blog bg, HttpPostedFileBase postedFile)
        {
            var addBlog = ct.Blogs.Add(bg);
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Images/BlogImages/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
                addBlog.BlogImage = "/Images/BlogImages/" + Path.GetFileName(postedFile.FileName);
                ViewBag.Message = "File uploaded successfully.";
            }
            else
            {
                addBlog.BlogImage = bg.BlogImage;
            }
            ct.SaveChanges();
            return RedirectToAction("MainBlog","Blog");
        }
        [Authorize]
        public ActionResult AdminCommentList(int page = 1)
        {
            var getAllComment = ct.Comments.ToList().ToPagedList(page, 10);
            return View(getAllComment);
        }
        [Authorize]
        public ActionResult DeleteComment(int id)
        {
            var findComment = ct.Comments.Find(id);
            ct.Comments.Remove(findComment);
            ct.SaveChanges();
            return RedirectToAction("AdminCommentList", "Admin");
        }
        [Authorize]
        public ActionResult ContactList(int page=1)
        {
            var getAllContact = ct.Contacts.ToList().ToPagedList(page, 10);
            return View(getAllContact);
        }
        [Authorize]
        public ActionResult DeleteContactMessage(int id)
        {
            var findMessage = ct.Contacts.Find(id);
            ct.Contacts.Remove(findMessage);
            ct.SaveChanges();
            return RedirectToAction("ContactList", "Admin");
        }
        [HttpGet]
        [Authorize]
        public ActionResult AdminUser()
        {
            var account = ct.Logins.Find(1);
            return View(account);
        }
        [HttpPost]
        public ActionResult AdminUser(Login log)
        {
            var updateUser = ct.Logins.Find(1);
            updateUser.Username = log.Username;
            updateUser.Password = log.Password;
            ct.SaveChanges();
            ViewBag.Basarili="Hesap Güncelleme İşleminiz Başarılı !!";
            return View();
        }

    }
}