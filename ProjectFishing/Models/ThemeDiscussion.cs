using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class ThemeDiscussion
    {
        [Key] // System.ComponentModel.DataAnnotations вынес в using, бро 
        public int ThemeDiscussionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Discussion> Discussions { get; set; }
        public ThemeDiscussion()
        {
            Discussions = new List<Discussion>();
        }
    }
}