using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resume_Portal.Models
{
    public class ProgramUsers
    {
        public int Id { get; set; }

        public int ProgramId { get; set; }
        public virtual Program Program { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}