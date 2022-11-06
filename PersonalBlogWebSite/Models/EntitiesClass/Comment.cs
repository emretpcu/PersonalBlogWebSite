using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalBlogWebSite.Models.EntitiesClass
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string CommentUsername { get; set; }
        public string CommentUserMail { get; set; }
        public string CommentExplanation { get; set; }
        public DateTime CommentDate { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

    }
}