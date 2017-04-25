using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SbdsSVol2.Models
{
    public class SbdSContext:DbContext
    {
        public DbSet<UserAccount> UserList { get; set; }
        public DbSet<Course> CoursList { get; set; }
        public DbSet<UserAtCourse>AtCourseList { get; set; }
    }
}