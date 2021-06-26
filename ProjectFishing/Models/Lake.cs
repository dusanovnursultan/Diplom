using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class Lake:Post
    {
        
        [DisplayName("Локация")]
        public string Location { get; set; }


        [DisplayName("Температура воды")]
        public string WaterTemperatureBySeasons { get; set; }


        [DisplayName("Качество воды")]
        public string QualityOfWater { get; set; }
        [DisplayName("Долгота ХХ,ХХ")]
        public float Longitude { get; set; }

        [DisplayName("Широта ХХ,ХХ")]
        public float Latitude { get; set; }

        

    }
}