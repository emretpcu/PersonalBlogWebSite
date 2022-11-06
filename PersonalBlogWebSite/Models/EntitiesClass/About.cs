using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalBlogWebSite.Models.EntitiesClass
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        public string AboutImage { get; set; }
        public string AboutExplanation { get; set; }
    }
}