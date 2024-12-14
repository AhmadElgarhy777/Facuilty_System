using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Timetable
    {
        public int TimetableId { get; set; }

        [Required]
        public string Day { get; set; } = null!;  

        [Required]
        public TimeSpan StartTime { get; set; }  

        [Required]
        public TimeSpan EndTime { get; set; }

        public bool? isDay { get; set; }


        public int? SectionId { get; set; }
        public Sections? Section { get; set; }

        // Allow LectureId to be nullable
        public int? LectureId { get; set; }
        public Lectures? Lecture { get; set; }
    }
}
