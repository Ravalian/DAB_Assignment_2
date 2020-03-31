using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment_2.Models
{
    public class Teacher
    {
        public string TeacherName { get; set; }
        public string TeacherAUid { get; set; }

        public Course Course { get; set; }
        public int courseId { get; set; }

    }
}
