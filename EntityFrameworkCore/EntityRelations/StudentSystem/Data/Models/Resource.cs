using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentSystem.Data.Models
{
    public class Resource
    {
        public enum TypeOfResource
        {
            Video, Presentation, Document, Other
        }

        [Key]
        public int ResourceId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "varchar(Max)")]
        public string Url { get; set; }

        public TypeOfResource ResourceType { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
