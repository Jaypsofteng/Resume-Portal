using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume_Portal.Models
{
    interface ViewModels
    {
    }
    public class ProgramViewModels : ViewModels
    {
        public string ProgramImagePath { get; set; }
        public Program program { get; set; }
    }
    public class StudentProfileViewModels : ViewModels
    {
        public StudentProfile studentProfile { get; set; }
        public Profile profile { get; set; }
    }
}
