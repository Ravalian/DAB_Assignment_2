using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment_OnlineHelpRequest.Models
{
    public class RequestHelpAssignments
    {
        public Student Student { get; set; }
        public string StudentId { get; set; }

        public Assignment Assignment { get; set; }
        public string AssignmentLecture { get; set; }
        public string AssignmentNumber { get; set; }

        public bool Isactive { get; set; } //Is the help request active or not
    }
}
