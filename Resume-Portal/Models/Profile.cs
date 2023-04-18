using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resume_Portal.Models
{
    public class Profile 
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string ProfilePic { get; set; }

        public string ShortDiscription { get; set; }
        // Just a few line discription.
        public string Role { get; set; }
    }

}