using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class PaginationModelTheme
    {
        public IPagedList<ThemeDiscussionViewModel> Themes { get; set; }
        public int? Page { get; set; }
        public int TotalDishesCount { get; set; }
    }
}