using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resume_Portal.Models
{
    public class NotifyAdmin
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string RoleName { get; set; }
        public DateTime RequestedOn { get; set; }
        public bool Resolved { get; set; }
    }
}