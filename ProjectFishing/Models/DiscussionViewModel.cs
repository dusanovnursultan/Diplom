using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class DiscussionViewModel
    {
        public Discussion Discussion { get; set; }
        public int CountThread { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
    }
}