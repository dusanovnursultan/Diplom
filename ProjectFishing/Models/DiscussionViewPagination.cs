using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class DiscussionViewPagination
    {

        // Pagination
        public int? Page { get; set; }
        public int TotalDiscussionCount { get; set; }
        public IPagedList<DiscussionViewModel> DiscussionPageList { get; set; }
    }
}