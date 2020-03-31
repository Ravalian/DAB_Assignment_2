using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment_2.Models
{
    public class Attends
    {
        public Student Student { get; set; }
        public Course Course { get; set; }

        public string StudentId { get; set; }
        public string StudentName { get; set; }

        public string CourseName { get; set; }
        public int CourseId { get; set; }

        public string Semester { get; set; }
    }
}
