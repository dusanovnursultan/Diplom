using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectFishing.Models
{
    public class Chat
    {
        [Key]
        public int ChatId { get; set; }

        public string RoomName { get; set; }

        public string MainUserName { get; set; }
        public string SecondaryUserName { get; set; }
        public string MainUser { get; set; }

        public string SecondaryUser { get; set; }
        public bool Read { get; set; }

        public virtual  List<Message> Messages { get; set; }
    }
}