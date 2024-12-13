using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StudentCourse
    {
        public int StudentCourseId { get; set; } // Primary key for StudentCourse

        public int CourseId { get; set; }
        //public EnumLevel CourseLevel { get; set; }

        public string StudentId { get; set; }
       // public EnumLevel Level { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }

        public int degree { get; set; }


    }
}
