using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resume_Portal.Models
{
    public class EmployerProfile 
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        // User id of application user will be indexed.
        [DataType(DataType.Text)]
        public string AboutUs { get; set; }

        [DataType(DataType.Text)]
        public string HistoryOfCompany { get; set; }

        [DataType(DataType.EmailAddress)]
        public string ContactUs { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }

        [DataType(DataType.Text)]
        public string LookingForSkills { get; set; }

        public virtual ICollection<Job> PostedJobs { get; set; }
    }
}