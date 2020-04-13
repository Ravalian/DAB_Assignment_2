using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment_OnlineHelpRequest.Models
{
    public class Teacher
    {
        public string TeacherName { get; set; }
        public string TeacherAUid { get; set; }

        public Course Course { get; set; }
        public string courseId { get; set; }

        public List<Assignment> TeacherAssignments { get; set; }

        public List<Exercise> TeacherExercises { get; set; }
    }
}
