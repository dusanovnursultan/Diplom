using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class CommentViewPagination
    {
        public int? Page { get; set; }
        public int TotalCommentCount { get; set; }
        public IPagedList<ForumCommentsViewModel> Comments { get; set; }
    }
}