using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MastersProject.Models
{
    public class SubjectEntity
    {
        public long Subjectid { get; set; }
        public string Subjectname { get; set; }
        public long Courseid { get; set; }
        public long Classid { get; set; }
        //public long trans_id { get; set; }
        public List<SubjectEntity> SubjectInfo { get; set; } = new List<SubjectEntity>();

        public CourseEntity courseEntity { get; set; }
        public ClassEntity classEntity { get; set; }

        public virtual TransactionEntity transaction { get; set; }
    }
}