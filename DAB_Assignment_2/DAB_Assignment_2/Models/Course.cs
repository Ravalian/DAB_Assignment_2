using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment_2.Models
{
    public class Course
    {
        public string CourseName { get; set; }
        public int courseId { get; set; }


        public List<Attends> Attends { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Exercise> Exercises { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
