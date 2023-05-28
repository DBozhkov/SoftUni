using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem.Data.Models
{
    public class StudentCourse
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
