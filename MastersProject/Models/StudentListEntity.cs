using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MastersProject.Models
{
    public class StudentListEntity
    {
        public long Studentid { get; set; }
        public string Studentname { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public Nullable<long> Pincode { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string PhoneNumber { get; set; }
        public long Courseid { get; set; }
        public long Classid { get; set; }
        public long Subjectid { get; set; }
        public string Emailid { get; set; }        
        public string Coursename { get; set; }
        public string Classname { get; set; }
        public string Subjectname { get; set; }
        public long Cid { get; set; }
        public long Sid { get; set; }
        public long Cityid { get; set; }
        public List<StudentListEntity> StudentInfo { get; set; }

        public CourseEntity courseEntity { get; set; }
        public ClassEntity classEntity { get; set; }
        public SubjectEntity subjectEntity { get; set; }        
        public CountryEntity countryEntity { get; set; }
        public StateEntity stateEntity { get; set; }
        public CityEntity cityEntity { get; set; }
        public TransactionEntity transaction { get; set; }


        
    }
}