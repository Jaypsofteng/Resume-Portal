using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resume_Portal.Models
{
    public class Activity
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        public string Discription { get; set; }

        [DataType(DataType.Text)]
        public string ImageUrl { get; set; }

        public ActivityType ActivityType { get; set; }

        public string UserId { get; set; }
        public virtual StudentProfile Student { get; set; }

    }

    public enum ActivityType
    {
        PersonalInterest,
        ClassActivity
    }
}