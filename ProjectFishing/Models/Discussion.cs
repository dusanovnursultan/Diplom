using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class Discussion
    {
        [Key]
        public int DiscussionId { get; set; }
        
        public string Date { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool Closed { get; set; }
        public ThemeDiscussion Theme { get; set; }
        public int CountView { get; set; }
        public string Image { get; set; }
    }
}