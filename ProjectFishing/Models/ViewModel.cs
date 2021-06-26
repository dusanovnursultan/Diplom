using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class ViewModel
    {
        public Post Post { get; set; }
        public List<Image>  Images { get; set; }
        public ViewModel()
        {
            Images = new List<Image>();
        }
    }
}