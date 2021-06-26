using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class ChatViewModel
    {
        public List<Chat> Chat { get; set; }
        public string ImageMainUser { get; set; }
        public string ImageSeconaryUser { get; set; }

    }
}