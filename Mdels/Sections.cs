using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Sections
    {
        public int SectionsID { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string SecURL { get; set; } = null!;
        public int CourseId { get; set; }
        public EnumLevel CourseLevel { get; set; }

        public Course Course { get; set; }
    }
}
