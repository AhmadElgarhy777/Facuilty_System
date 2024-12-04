using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Tracing;

namespace Models.ViewModels
{
    public class StudentVM
    {
        [Required]
        [MaxLength(14)]
        public string SSN { get; set; } = null!;
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(20)]
        public string FName { get; set; } = null!;
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(40)]
        public string MName { get; set; } = null!;
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(20)]
        public string LName { get; set; } = null!;
        

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
        [Required]
        public int DepartmentId { get; set; }


    }
}
