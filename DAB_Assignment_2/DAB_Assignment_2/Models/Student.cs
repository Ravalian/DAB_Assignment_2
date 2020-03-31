using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment_2.Models
{
    public class Student
    {
        public string StudentName { get; set; }
        public string StudentAUid { get; set; }

        public List<Exercise> Exercises { get; set; }
        public List<RequestHelpAssignments> RequestHelpAssignments { get; set; }
        public List<Attends> Attends { get; set; }
        //public List<HelpRequestExercises> HelpRequestExercises { get; set; }

    }
}
