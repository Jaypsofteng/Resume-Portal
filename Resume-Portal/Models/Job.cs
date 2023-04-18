using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resume_Portal.Models
{
    public class Job
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        public string CompanyName { get; set; }

        public DateTime PostedOn { get; set; }

        [DataType(DataType.Text)]
        public string JobDiscription { get; set; }

        public string EmployerId { get; set; }
        public virtual EmployerProfile Employer { get; set; }

        public int ProgramId { get; set; }
        public virtual Program Program { get; set; }
    }
}