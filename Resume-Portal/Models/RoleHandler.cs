using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Text;

namespace Resume_Portal.Models
{
    public class RoleHandler
    {
        private protected UserManager<IdentityUser> userManager { get; set; }
        private protected RoleManager<IdentityRole> RoleManager { get; set; }
        private protected ApplicationDbContext db;

        public RoleHandler()
        {
            db = new ApplicationDbContext();
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
            RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            // Initilizing manager instances.
        }

        public bool SeedDatabaseWithRoles()
        {
            RoleManager.Create(new IdentityRole("Admin"));
            RoleManager.Create(new IdentityRole("Student"));
            RoleManager.Create(new IdentityRole("Employer"));
            RoleManager.Create(new IdentityRole("Instructor"));
            return true;
        }

        public void CreateFile(string filename)
        {
            string path = @"C:\Users\jay\source\repos\Resume-Portal\ProgramsData\programdetails\" + @filename + ".txt";

            var file = File.Create(path);
            file.Close();
        }

        public void SeedDatabaseWithPrograms()
        {
            string path = @"C:\Users\jay\source\repos\Resume-Portal\ProgramsData\programNames.txt";

            using (StreamReader sr = File.OpenText(path))
            {
                string programName;
                while ((programName = sr.ReadLine()) != null)
                {
                    CreateFile(programName);
                }

            }

        }

        // Add online offline status to user.
        // Add Last login time to user.

        public void UpdateUserLoginStatus(string userEmail)
        {
            var userId = userManager.FindByEmail(userEmail).Id;
            if (userId != "")
            {// This If will never be false. Just to be sure.
                var user = db.Users.Find(userId);
                user.LastLogedIn = DateTime.Now;
                user.Online = true;
                db.SaveChanges();
            }
        }

        public void UpdateInvalidTry(string userEmail)
        {
            var user = userManager.FindByEmail(userEmail);
            if (user != null)
            {// This If will never be false. Just to be sure.
                user.AccessFailedCount += 1;
                db.SaveChanges();

            }
        }

        public void UpdateUserLogOffStatus(string userId)
        {
            if (userId != "")
            {// This If will never be false. Just to be sure.
                var user = db.Users.Find(userId);
                if (user != null)
                {
                    user.Online = false;
                    db.SaveChanges();

                }
            }
        }

        private protected void CreateProfile(string userId, string RoleName)
        {
            Profile profile = new Profile();
            profile.UserId = userId;
            profile.UserName = db.Users.Find(userId).UserName;
            profile.ShortDiscription = "";
            profile.ProfilePic = "";
            profile.Role = RoleName;
            db.Profiles.Add(profile);
            db.SaveChanges();
            bool flag = false;
            if (RoleName == "Instructor")
            {
                InstructorProfile instructorProfile = new InstructorProfile();
                instructorProfile.UserId = userId;
                instructorProfile.JoinedMitt = DateTime.Now;
                db.InstructorProfiles.Add(instructorProfile);
                db.SaveChanges();
                flag = true;
            }
            else if (RoleName == "Employer")
            {
                EmployerProfile employerProfile = new EmployerProfile();
                employerProfile.UserId = userId;
                db.EmployerProfiles.Add(employerProfile);
                db.SaveChanges();
                flag = true;
            }
            else if (RoleName == "Student")
            {
                StudentProfile studentProfile = new StudentProfile();
                studentProfile.StartDate = DateTime.Now;
                studentProfile.EndDate = DateTime.Now;
                studentProfile.UserId = userId;
                db.StudentProfiles.Add(studentProfile);
                db.SaveChanges();
                flag = true;
            }
            if (flag == true)
            {
                NotifyAdmin notifyAdmin = db.NotifyAdmins.Where(x => x.UserId == userId).FirstOrDefault();
                notifyAdmin.Resolved = true;
                db.SaveChanges();
            }
        }

        private protected void RemoveProfile(string userId, string RoleName)
        {
            Profile p = db.Profiles.ToList().Where(x => x.UserId == userId).FirstOrDefault();
            db.Profiles.Remove(p);
            db.SaveChanges();
            if (RoleName == "Instructor")
            {
                InstructorProfile instructorProfile = db.InstructorProfiles.Where(x => x.UserId == userId).FirstOrDefault();
                db.InstructorProfiles.Remove(instructorProfile);
                db.SaveChanges();
            }
            else if (RoleName == "Employer")
            {

                EmployerProfile employerProfile = db.EmployerProfiles.Where(x => x.UserId == userId).FirstOrDefault();
                db.EmployerProfiles.Remove(employerProfile);
                db.SaveChanges();
            }
            else if (RoleName == "Student")
            {
                StudentProfile studentProfile = db.StudentProfiles.Where(x => x.UserId == userId).FirstOrDefault();
                db.StudentProfiles.Remove(studentProfile);
                db.SaveChanges();
            }

        }

        public bool AssignUserToRole(string UserId, string RoleName)
        {
            var user = userManager.FindById(UserId);
            if (user == null || (!RoleManager.RoleExists(RoleName)))
            {
                return false;
            }


            bool result = userManager.AddToRole(UserId, RoleName).Succeeded;
            // Create a user profile instance. also create a profilr based on role.
            CreateProfile(UserId, RoleName);
            return result;
        }

        public bool UnassignUserToRole(string UserId, string RoleName)
        {
            var user = userManager.FindById(UserId);
            if (user == null || (!RoleManager.RoleExists(RoleName)))
            {
                return false;
            }


            bool result = userManager.RemoveFromRole(UserId, RoleName).Succeeded;
            // remove profile and userprofile instances.
            RemoveProfile(UserId, RoleName);

            return result;
        }

        public bool UserRequestedRegistration(string userEmail, string roleName)
        {
            var user = db.Users.Where(x => x.Email == userEmail).FirstOrDefault();
            bool result = false;
            if (userEmail == "" || user.Id == "" || roleName == "")
            {
                return result;
            }

            NotifyAdmin notifyAdmin = new NotifyAdmin();
            notifyAdmin.RequestedOn = DateTime.Now;
            notifyAdmin.Resolved = false;
            notifyAdmin.RoleName = roleName;
            notifyAdmin.UserId = user.Id;
            notifyAdmin.UserEmail = userEmail;
            db.NotifyAdmins.Add(notifyAdmin);
            db.SaveChanges();

            result = true;


            return result;

        }

        public List<string> GetAllRoles()
        {
            var result = RoleManager.Roles.ToList().Select(x => x.Name).Distinct().ToList();
            return result;
        }


        public void SeedPrograms()
        {
            string names = @"C:\Users\jay\source\repos\Resume-Portal\ProgramsData\programNames.txt";
            string data = @"C:\Users\jay\source\repos\Resume-Portal\ProgramsData\programdetailsParsed\";
            using (StreamReader sr = File.OpenText(names))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string path = data + s + ".txt";
                    var details = File.ReadAllLines(path);
                    StringBuilder sb = new StringBuilder();
                    foreach (string line in details)
                    {
                        var words = line.Split(' ');
                        foreach (string word in words)
                        {
                            if (word != "")
                            {
                                sb.Append(word);
                                sb.Append("\t");
                            }
                        }
                    }

                    var st = sb.ToString();
                    Program program = new Program();
                    program.Name = s;
                    program.Discription = st;
                    //db.Programs.Add(program);
                    //db.SaveChanges();
                }
            }



        }
    }
}