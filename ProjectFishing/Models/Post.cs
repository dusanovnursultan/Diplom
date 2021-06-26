using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    /// <summary>
    /// Ad=0; Fish=1; Lake=2
    /// </summary>
    public enum PostCategory
    {
        Ad=0,
        Fish=1,
        Lake=2,
        Shop=3

    }
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        public int PostCategory { get; set; }

        public   List<Image> Images { get; set; }
      
       
    }
}