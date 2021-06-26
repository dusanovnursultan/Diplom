using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class PostViewModel
    {
        public int? Page { get; set; }
        public int TotalDishesCount { get; set; }
        public IPagedList<ViewModel> Posts { get; set; }
    }
}