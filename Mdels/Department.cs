﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]

        public string Description { get; set; } = null!;
        public string NumOfStudent { get; set; }
        public string NumOfCourses { get; set; }
        public ICollection<Student> Students { get; } = new List<Student>();
        public ICollection<Member> members { get; } = new List<Member>();
        public ICollection<Course> Courses { get; } = new List<Course>();

        public ICollection<Employee> Employees { get; } = new List<Employee>();


    }
}
