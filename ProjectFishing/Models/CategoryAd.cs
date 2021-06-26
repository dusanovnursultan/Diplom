using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class CategoryAd
    {
      
        public int CategoryAdId { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
    }
}