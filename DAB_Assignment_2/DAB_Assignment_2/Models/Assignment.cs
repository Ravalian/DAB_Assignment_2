using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment_2.Models
{
    public class Assignment
    {
        public List<RequestHelpAssignments> RequestHelpAssignmentses { get; set; }

        public string helpwhere { get; set; }
        public string lecture { get; set; }
        public int number { get; set; }

        public Course Course { get; set; }
        public int courseId { get; set; }

    }
}
