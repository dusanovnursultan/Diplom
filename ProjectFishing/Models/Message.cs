using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        public string MessageText { get; set; }

        public string Date { get; set; }

        public string SenderName { get; set; }
       
        public  Chat Chat { get; set; }
    }
}