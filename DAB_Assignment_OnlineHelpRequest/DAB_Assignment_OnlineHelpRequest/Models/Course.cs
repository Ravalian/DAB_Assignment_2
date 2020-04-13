using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment_OnlineHelpRequest.Models
{
    public class Course
    {
        public string CourseName { get; set; }
        public string courseId { get; set; }


        public List<Attends> Attends { get; set; }
        public List<Assignment> CourseAssignments { get; set; }
        public List<Exercise> CourseExercises { get; set; }
        public List<Teacher> CourseTeachers { get; set; }
    }
}