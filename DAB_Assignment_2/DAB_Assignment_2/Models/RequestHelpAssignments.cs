using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment_2.Models
{
    public class RequestHelpAssignments
    {
        public Student Student { get; set; }
        public string StudentName { get; set; }
        public string StudentId { get; set; }

        public Assignment Assignment { get; set; }
        public string AssignmentLecture { get; set; }
        public int AssignmentNumber { get; set; }
        public string AssignmentHelpWhere { get; set; }


        //Feeling cute, might delete later
        public int RequestHelpAssignmentID { get; set; }

    }
}
