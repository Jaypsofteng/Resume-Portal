using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resume_Portal.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public string Discription { get; set; }

        public IntendedUser IntendedUser { get; set; }

        public string UrlPath { get; set; }

        public DateTime CreatedOn { get; set; }
    }

    public enum IntendedUser
    {
        Student,
        Instructor,
        Employer
    }
}