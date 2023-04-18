namespace Resume_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Discription = c.String(),
                        ImageUrl = c.String(),
                        ActivityType = c.Int(nullable: false),
                        UserId = c.String(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentProfiles", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.StudentProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        AboutMe = c.String(),
                        ContactInfo = c.String(),
                        ProfessionalEmail = c.String(),
                        SemesterNumber = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        MySkills = c.String(),
                        Event_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        FileName = c.String(nullable: false, maxLength: 128),
                        FilePath = c.String(),
                        uploaded = c.DateTime(nullable: false),
                        StudentId = c.String(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.FileName)
                .ForeignKey("dbo.StudentProfiles", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.EmployerProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        AboutUs = c.String(),
                        HistoryOfCompany = c.String(),
                        ContactUs = c.String(),
                        PhoneNo = c.String(),
                        LookingForSkills = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        PostedOn = c.DateTime(nullable: false),
                        JobDiscription = c.String(),
                        EmployerId = c.String(),
                        ProgramId = c.Int(nullable: false),
                        Employer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployerProfiles", t => t.Employer_Id)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.ProgramId)
                .Index(t => t.Employer_Id);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Discription = c.String(),
                        Duration = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProgramUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProgramId = c.Int(nullable: false),
                        UserId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.ProgramId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Online = c.Boolean(nullable: false),
                        LastLogedIn = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventDiscription = c.String(),
                        Date = c.DateTime(nullable: false),
                        StartTime = c.String(),
                        EndTime = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InstructorProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        AboutMe = c.String(),
                        Experience = c.String(),
                        JoinedMitt = c.DateTime(nullable: false),
                        ContactInfo = c.String(),
                        ProfetionalEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Discription = c.String(),
                        IntendedUser = c.Int(nullable: false),
                        UrlPath = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NotifyAdmins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        UserEmail = c.String(),
                        RoleName = c.String(),
                        RequestedOn = c.DateTime(nullable: false),
                        Resolved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        UserName = c.String(),
                        ProfilePic = c.String(),
                        ShortDiscription = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.StudentProfiles", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.ProgramUsers", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.ProgramUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Jobs", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.Jobs", "Employer_Id", "dbo.EmployerProfiles");
            DropForeignKey("dbo.Attachments", "Student_Id", "dbo.StudentProfiles");
            DropForeignKey("dbo.Activities", "Student_Id", "dbo.StudentProfiles");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ProgramUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ProgramUsers", new[] { "ProgramId" });
            DropIndex("dbo.Jobs", new[] { "Employer_Id" });
            DropIndex("dbo.Jobs", new[] { "ProgramId" });
            DropIndex("dbo.Attachments", new[] { "Student_Id" });
            DropIndex("dbo.StudentProfiles", new[] { "Event_Id" });
            DropIndex("dbo.Activities", new[] { "Student_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Profiles");
            DropTable("dbo.NotifyAdmins");
            DropTable("dbo.Notifications");
            DropTable("dbo.InstructorProfiles");
            DropTable("dbo.Events");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ProgramUsers");
            DropTable("dbo.Programs");
            DropTable("dbo.Jobs");
            DropTable("dbo.EmployerProfiles");
            DropTable("dbo.Attachments");
            DropTable("dbo.StudentProfiles");
            DropTable("dbo.Activities");
        }
    }
}
