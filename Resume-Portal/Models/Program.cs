using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IO;

namespace Resume_Portal.Models
{
    public class Program
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Discription { get; set; }

        public string Duration { get; set; }
    
        public virtual ICollection<ProgramUsers> ProgramUsers { get; set; }

        public virtual ICollection<Job> PostedJobs { get; set; }
    
    }
}