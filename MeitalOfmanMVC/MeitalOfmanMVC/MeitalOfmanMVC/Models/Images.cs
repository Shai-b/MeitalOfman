using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeitalOfmanMVC.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public int PostId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }

    }
}