using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;


namespace PersonalBlogWebSite.Models.EntitiesClass
{
    public class BlogDetailsModel
    {
        public IEnumerable<Blog> ValueBlog { get; set; }
        public IEnumerable<Comment> ValueComment { get; set; }

        //
        public IEnumerable<Blog> LastBlog { get; set; }
        public IEnumerable<Comment> LastComment { get; set; }
        public IEnumerable<Blog> FirstBlog { get; set; }
        //
        public IEnumerable<Blog> AllBlog { get; set; }


    }
}