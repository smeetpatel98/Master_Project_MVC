//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MastersProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_subject
    {
        public tbl_subject()
        {
            this.tbl_studentlistpage = new HashSet<tbl_studentlistpage>();
        }
    
        public long Subjectid { get; set; }
        public string Subjectname { get; set; }
        public long Courseid { get; set; }
        public long Classid { get; set; }
        public long trans_id { get; set; }
    
        public virtual tbl_class tbl_class { get; set; }
        public virtual tbl_course tbl_course { get; set; }
        public virtual tbl_transaction tbl_transaction { get; set; }
        public virtual ICollection<tbl_studentlistpage> tbl_studentlistpage { get; set; }
    }
}
