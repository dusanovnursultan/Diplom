using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class AdViewModel
    {
        public Ad Ad { get; set; }

        public List<string> Images { get; set; }
        public AdViewModel()
        {
            Images = new List<string>();
        }
    }
}