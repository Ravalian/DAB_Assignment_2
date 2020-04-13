using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment_OnlineHelpRequest.Models
{
    public class Assignment
    {
        public List<RequestHelpAssignments> RequestHelpAssignmentses { get; set; }

        public string helpwhere { get; set; }
        public string lecture { get; set; }
        public string number { get; set; }

        public Course Course { get; set; }
        public string courseId { get; set; }

        public Teacher Teacher { get; set; }
        public string TeacherAUid { get; set; }
    }
}
