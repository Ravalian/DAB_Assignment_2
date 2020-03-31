using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Assignment_2.Models
{
    public class Exercise
    {
        public string helpwhere { get; set; }
        public string lecture { get; set; }
        public int number { get; set; }

        public Student student { get; set; }
        public string StudentAUid { get; set; }

        public Course Course { get; set; }
        public int courseId { get; set; }

        //public List<HelpRequestExercises> HelpRequestExercises { get; set; }
    }
}
