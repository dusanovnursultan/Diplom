using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class ForumCommentsViewModel
    {
        public ForumComment Comment { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
    }
}