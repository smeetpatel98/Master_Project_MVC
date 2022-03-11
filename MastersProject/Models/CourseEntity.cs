using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MastersProject.Models
{
    public class CourseEntity
    {
        public long Courseid { get; set; }
        public string Coursename { get; set; }
        public long trans_id { get; set; }
        public List<CourseEntity> CourseInfo { get; set; } = new List<CourseEntity>();
        public virtual TransactionEntity transaction { get; set; }
    }
}