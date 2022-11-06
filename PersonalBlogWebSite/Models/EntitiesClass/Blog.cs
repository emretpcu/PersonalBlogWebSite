using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalBlogWebSite.Models.EntitiesClass
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string BlogTitle { get; set; }
        public string BlogExplanation { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}