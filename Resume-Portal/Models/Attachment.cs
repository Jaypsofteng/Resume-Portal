using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resume_Portal.Models
{
    public class Attachment
    {
        [Key]
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime uploaded { get; set; }
        public string StudentId { get; set; }
        public virtual StudentProfile Student { get; set; }
    }


    public class ImageRetrive
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static string GetImageUrl(string userID)
        {
            string folderName = (db.ProgramUsers.Where(x => x.UserId == userID).FirstOrDefault()).ProgramId.ToString();
            // Directory structure... Program id // userId // profilepic.jpg
            // When user updates profile picture a previous picture will be removed. Only 
            string pictureUrl = folderName + userID + "profilepic.jpg";

            return pictureUrl;
        }
    }

}