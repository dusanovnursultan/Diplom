using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class ForumComment
    {
        public int ForumCommentsId { get; set; }
        public string Text { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
        public string UserId { get; set; }
        public string WhoToAnswer { get; set; }
        public int Discussion { get; set; }
        public string Image { get; set; }
    }
}