# Mitt Internship Portal System
## About this Project
This project is to create an internship portal for both Students and Employers for Mitt College's Internship Program.

# Project OutLine
Users
Students
Employers
Instructors

### User Requirements
### Student
- Full Name
- Student Number
- Email
- Phone Number
- Program Objects
- Attachments Objects
- Activities Objects
### Instructor
- Full Name
- Program Objects
- Email
- Phone Number
### Employer 
- Company Name
- Company Email
- Company Phone Number
- Company Description
- Chosen Programs
- InternShips Objects
## User Functionalities
### Students 
1. Students will wait for their profile to be authorized on creation.
1. Students must be authorized to a program by an instructor/Admin.
1. Students can sign up to the portal with contact info.
1. Students can see Internships based off programs(courses).
1. Students can upload attachments to their profiles.
1. Students can apply for internships and send the employer a message and any attachments.
1. Students can only view Employers profiles, and internship postings.
### Instructors
1. Instructors must have one program to instruct. 
1. Only Admins can approve new instructors.
1. Instructors can approve new students to their programs.
1. Instructors have the ability to add new employer profiles.
1. Instructors can recommand internships by sending notifications to students and employers.
1. Instructors can view all profiles.
### Employers 
1. Instructors/Admins create/authorize new employer profiles. 
1. Employers can post a internship on the portal.
1. Internships gets added to a round based off of start dates and end dates for the internship.
1. new interships gets added to their related lists(programs, rounds).
1. Employers can see list of students that relates to their internship requirements.

Required Software:
Visual Studio 2022 and compatible .Net Framework 
Microsoft® SQL Server® 2022 Express

## Setup Steps:
1> Clone the project `git clone https://github.com/Jaypsofteng/Resume-Portal.git`

2> Run Database migration using nuget package manager console or dotnet ef tool
    - `Update-Database` in nuget package manager console or 
    - `dotnet ef database update -- --environment Test`

## Images showcasing basic application overview
[![User Login page](/Resume-Portal/Project-Images/UserLogin.png)](https://github.com/Jaypsofteng/Resume-Portal.git)
[![User Registration page](/Resume-Portal/Project-Images/UserRegistration.png)](https://github.com/Jaypsofteng/Resume-Portal.git)
[![Landing page](/Resume-Portal/Project-Images/AllPrograms.png)](https://github.com/Jaypsofteng/Resume-Portal.git)

Note: Application requires extra curated seeding of database for static contents.