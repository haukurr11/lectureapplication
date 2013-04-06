using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MyLectureApplication.Models
{
    public class AppDataContext : DbContext
    {
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }

}