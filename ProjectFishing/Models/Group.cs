using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}