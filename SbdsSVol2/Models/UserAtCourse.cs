using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SbdsSVol2.Models
{
    public class UserAtCourse
    {
        [Key]
        public int AtCourseId { get; set; }
        

        [ForeignKey("UserAccount")]
        public int UserId { get; set; }
        public UserAccount UserAccount { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}