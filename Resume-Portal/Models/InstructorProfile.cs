using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Resume_Portal.Models
{
    public class InstructorProfile 
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [DataType(DataType.Text)]
        public string AboutMe { get; set; }

        [DataType(DataType.Text)]
        public string Experience { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoinedMitt { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string ContactInfo { get; set; }

        [DataType(DataType.EmailAddress)]
        public string ProfetionalEmail { get; set; }
    }
}