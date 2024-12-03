﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Member
    {
        public int MemberId { get; set; }
        [Required]
        [DataType(DataType.Text)]

        public string FName { get; set; } = null!;
        [Required]
        [DataType(DataType.Text)]

        public string MName { get; set; } = null!;
        [Required]
        [DataType(DataType.Text)]

        public string LName { get; set; } = null!;
        [NotMapped]
        public string FullName { get; set; } = null!;
        [Required]

        public EnumGender Gender { get; set; }
        [Required]

        public string Address { get; set; } = null!;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required]

        [DataType(DataType.Text)]

        public string Nationailty { get; set; } = null!;
        [Required]

        public DateTime BirthDate { get; set; }
        [NotMapped]
        public int Age { get; set; }
        public int Experence { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<MemberPhone> memberPhones { get; set; }
    }
}
