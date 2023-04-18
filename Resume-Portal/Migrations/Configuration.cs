namespace Resume_Portal.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNetCore.Identity;
    using Resume_Portal.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Resume_Portal.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Resume_Portal.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            var roleManager = new Microsoft.AspNet.Identity.RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
                roleManager.Create(new IdentityRole("Instructor"));
                roleManager.Create(new IdentityRole("Student"));
                roleManager.Create(new IdentityRole("Employer"));
            }
            if (!context.Users.Any(u => u.UserName == "Admin@test.com"))
            {
                ApplicationUser Admin = new ApplicationUser { UserName = "Admin@test.com", Email = "Admin@test.com", LastLogedIn = DateTime.Now };
                userManager.Create(Admin, "EntityFr@mew0rk");
                userManager.AddToRole(Admin.Id, "Admin");
            }
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
