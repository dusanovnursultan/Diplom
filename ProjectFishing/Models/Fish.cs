using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class Fish:Post
    {
        [DisplayName("Вид")]
        public string ClassificationOfFish { get; set; }


        [DisplayName("Размеры")]
        public string Size { get; set; }

        [DisplayName("Среды обитания")]
        public string Habitats { get; set; }

        [DisplayName("Наживка")]
        public string Baits { get; set; }

        [DisplayName("Способ ловли")]
        public string FishingMethod { get; set; }

        [DisplayName("Время нереста")]
        public string SpawningTime { get; set; }

       
    }
}