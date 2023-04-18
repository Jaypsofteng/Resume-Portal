using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Resume_Portal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public bool Online { get; set; }

        public DateTime LastLogedIn { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Program> Programs { get; set; }

        public DbSet<ProgramUsers> ProgramUsers { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<InstructorProfile> InstructorProfiles { get; set; }

        public DbSet<StudentProfile> StudentProfiles { get; set; }

        public DbSet<EmployerProfile> EmployerProfiles { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<NotifyAdmin> NotifyAdmins { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


    }
}