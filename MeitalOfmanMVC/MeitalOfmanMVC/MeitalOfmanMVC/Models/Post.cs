using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeitalOfmanMVC.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Headline { get; set; }
        public string SubText { get; set; }
        public List<Image> Images { get; set; }
    }
}