using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Required]
        public int Hourse { get; set; }
        [Required]
        public int Degree { get; set; }
        [Required]
        public string DocumentUrl { get; set; } = null!;
        [Required]
        public EnumLevel CourseLevel { get; set; }

        public List<Lectures> Lectures { get; set; }
        public List<Sections> Sections { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }


    }
}
