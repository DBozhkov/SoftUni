using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentSystem.Data.Models
{
    public class Homework
    {
        public enum TypeOfContent
        {
            Application, Pdf, Zip
        }

        [Key]
        public int HomeworkId { get; set; }

        [Required]
        public string Content { get; set; }

        public TypeOfContent ContentType { get; set; }

        [Required]
        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
