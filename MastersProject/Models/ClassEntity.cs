using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MastersProject.Models
{
    public class ClassEntity
    {
        public long Classid { get; set; }
        public string Classname { get; set; }
        public long Courseid { get; set; }
        public long trans_id { get; set; }
        public List<ClassEntity> ClassInfo { get; set; } = new List<ClassEntity>();
        public CourseEntity courseEntity { get; set; }
        public virtual TransactionEntity transaction { get; set; }

        //public virtual tbl_course course { get; set; }
        
    }
}