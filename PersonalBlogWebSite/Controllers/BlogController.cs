using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalBlogWebSite.Models.EntitiesClass;
using PagedList.Mvc;
using PagedList;

namespace PersonalBlogWebSite.Controllers
{
    public class BlogController : Controller
    {
        BlogDetailsModel bdm = new BlogDetailsModel();
        Context ct = new Context();
        public ActionResult MainBlog()
        {
            bdm.ValueBlog = ct.Blogs.ToList();
            bdm.LastBlog = ct.Blogs.OrderByDescending(i => i.Id).Take(3).ToList();
            bdm.LastComment = ct.Comments.OrderByDescending(i => i.Id).Take(3).ToList();
            return View(bdm);
        }
        public PartialViewResult PartialBlog(int page=1)
        {
            var getAllBlog = ct.Blogs.ToList().ToPagedList(page, 3);
            return PartialView(getAllBlog);
        }
        [HttpGet]
        public ActionResult BlogDetails(int id)
        {   
            bdm.ValueBlog = ct.Blogs.Where(x => x.Id == id).ToList();
            bdm.ValueComment = ct.Comments.Where(x => x.BlogId == id).ToList();
            bdm.LastBlog = ct.Blogs.OrderByDescending(i=> i.Id).Take(3).ToList();
            bdm.LastComment = ct.Comments.OrderByDescending(i=> i.Id).Take(3).ToList();
            bdm.AllBlog=ct.Blogs.ToList();
            return View(bdm);
        }
        [HttpPost]
        public ActionResult BlogDetails(Comment item,int id)
        {
            var addComment = ct.Comments.Add(item);
            addComment.BlogId = id;
            ct.SaveChanges();
            return RedirectToAction("/BlogDetails/"+id,"Blog");
            
        }

    }
}