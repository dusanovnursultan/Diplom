using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class Shop:Post
    {
    
     
      
        [DisplayName("Рейтинг")]
        public int Rating { get; set; }

        [DisplayName("Часы работы")]
        public string WorkingHours { get; set; }

        [DisplayName("Телефон")]
        public string Phone { get; set; }

        
    }
}