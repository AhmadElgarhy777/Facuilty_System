using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(6)]
        public string FName { get; set; } = null!;
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(6)]
        public string MName { get; set; } = null!;
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(6)]
        public string LName { get; set; } = null!;
        [NotMapped]
        public string FullName { get; set; } = null!;
        
        [Required]
        public EnumGender Gender { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Address { get; set; } = null!;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required]

        public EnumLevel Level { get; set; }
        [Required]
        public string Nationailty { get; set; } = null!;
        [Required]

        public DateTime BirthDate { get; set; }
        [NotMapped]
        public int Age { get; set; }
        
        public List<StudentCourse> StudentCourses { get; set; }

        public List<StudentPhone> studentPhones { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }



    }
}
