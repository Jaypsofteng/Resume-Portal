using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Resume_Portal.Models
{

    public class StudentProfile 
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [DataType(DataType.Text)]
        public string AboutMe { get; set; }
        // Broad Discription about me.

        //Each student is in only one program. 
        [DataType(DataType.PhoneNumber)]
        public string ContactInfo { get; set; }

        [DataType(DataType.EmailAddress)]
        public string ProfessionalEmail { get; set; }

        [Required]
        public int SemesterNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [DataType(DataType.Text)]
        public string MySkills { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        // All activities related to student.
        public virtual ICollection<Attachment> Attachments { get; set; }
    }

    // Partial student profile view mode for list.
    public class StudentPartialViewModel
    {
        public string StudentId { get; set; }

        public string SortDiscription { get; set; }

        public string MySkills { get; set; }

        public string ContactInfo { get; set; }

        public string ProfessionalEmail { get; set; }

        public string ProfilePicUrl { get; set; }
    }

    public class StudentHelper
    {

        private static ApplicationDbContext db = new ApplicationDbContext();

        public static List<StudentPartialViewModel> CreatePartialModel(List<string> studentIDS)
        {
            List<StudentPartialViewModel> StudentInfo = new List<StudentPartialViewModel>();
            if (studentIDS.Count() == 0)
            {
                return StudentInfo;
            }
            foreach (var uId in studentIDS)
            {
                var student = db.StudentProfiles.Find(uId);
                if (student != null)
                {
                    // Only students will be retrive.
                    StudentPartialViewModel studentPartialView = new StudentPartialViewModel();
                    studentPartialView.StudentId = student.UserId;
                   // studentPartialView.SortDiscription = student.ShortDiscription;
                    studentPartialView.ProfessionalEmail = student.ProfessionalEmail;
                    studentPartialView.MySkills = student.MySkills;
                    StudentInfo.Add(studentPartialView);
                }
            }



            return StudentInfo;
        }
    }

}