using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class NewsViewModel
    {
        public int? Page { get; set; }
        public int TotalDishesCount { get; set; }
        public IPagedList<News> News { get; set; }
    }
}