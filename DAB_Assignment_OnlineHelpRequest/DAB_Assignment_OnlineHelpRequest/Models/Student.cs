using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment_OnlineHelpRequest.Models
{
    public class Student
    {
        public string StudentName { get; set; }
        public string StudentAUid { get; set; }

        public List<Exercise> StudentExercises { get; set; }
        public List<RequestHelpAssignments> RequestHelpAssignments { get; set; }
        public List<Attends> Attends { get; set; }
    }
}
