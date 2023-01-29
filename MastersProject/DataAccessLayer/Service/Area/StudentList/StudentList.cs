using MastersProject.DataAccessLayer.Area.StudentList;
using MastersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MastersProject.DataAccessLayer.Service.Area.StudentList
{
    public class StudentList : ModelAccess, IStudentList
    {
        Master_MVCEntities1 db = new Master_MVCEntities1();

        private ResponseResult responseResult;
        public StudentList()
        {
            responseResult = new ResponseResult();
        }
        public async Task<bool> CheckStudentListExist(string Studentname, long Studentid)
        {
            bool isExists = this.context.tbl_studentlistpage.Where(x => (Studentid == 0 || x.Studentid != Studentid) && x.Studentname.ToLower() == Studentname.ToLower()).FirstOrDefault() != null;
            return isExists;
        }

        public async Task<List<StudentListEntity>> GeAllStudent()
        {
            var StudentInfo = (from u in this.context.tbl_studentlistpage
                               select new StudentListEntity()
                               {
                                Studentid=u.Studentid,
                                Studentname=u.Studentname,
                                Address=u.Address,
                                Country=u.Country,
                                State=u.State,
                                City=u.City,
                                Pincode=u.Pincode,
                                DOB=u.DOB,
                                PhoneNumber=u.PhoneNumber,
                                Emailid=u.Emailid,
                                Coursename=u.Coursename,
                                Classname=u.Classname,
                                Subjectname=u.Subjectname,

                                    courseEntity = new CourseEntity()
                                    {
                                     Courseid=u.tbl_course.Courseid,
                                     Coursename=u.tbl_course.Coursename
                                    },
                                    classEntity=new ClassEntity()
                                    {
                                    Classid=u.tbl_class.Classid,
                                    Classname=u.tbl_class.Classname
                                    },
                                    subjectEntity  = new SubjectEntity()
                                    {
                                    Subjectid=u.tbl_subject.Subjectid,
                                    Subjectname=u.tbl_subject.Subjectname
                                    },
                                    countryEntity = new CountryEntity()
                                    {
                                        Cid=u.tbl_country.Cid,
                                        Cname=u.tbl_country.Cname
                                    },
                                    stateEntity = new StateEntity()
                                    {
                                        Sid=u.tbl_state.Sid,
                                        Sname=u.tbl_state.Sname
                                    },
                                    cityEntity = new CityEntity()
                                    {
                                        Cityid=u.tbl_city.Cityid,
                                        Cityname=u.tbl_city.Cityname
                                    }

                               }).ToList();
            return StudentInfo;
        }

        public async Task<StudentListEntity> GetStudentbyid(long Student)
        {
            //Edit code 
            StudentListEntity studentEntity = new StudentListEntity();
            var u = this.context.tbl_studentlistpage.Where(a => a.Studentid == Student).FirstOrDefault();
            if (u!= null)
            {
                studentEntity.Studentid = u.Studentid;
                studentEntity.Studentname = u.Studentname;
                studentEntity.Address = u.Address;
                studentEntity.Cid = u.Cid;
                studentEntity.Country = u.Country;
                studentEntity.Sid = u.Sid;
                studentEntity.State = u.State;
                studentEntity.Cityid = u.Cityid;
                studentEntity.City = u.City;
                studentEntity.Pincode = u.Pincode;
                studentEntity.DOB = u.DOB;
                studentEntity.PhoneNumber = u.PhoneNumber;
                studentEntity.Emailid = u.Emailid;
                studentEntity.Courseid = u.Courseid;
                studentEntity.Coursename = u.Coursename;
                studentEntity.Classid = u.Classid;
                studentEntity.Classname = u.Classname;
                studentEntity.Subjectid = u.Subjectid;
                studentEntity.Subjectname = u.Subjectname;
            }
            return studentEntity;
        }

        public async Task<ResponseResult> RemoveStudentList(long Studentid)
        {
            try
            {
                var delete = (from d in this.context.tbl_studentlistpage
                              where d.Studentid == Studentid
                              select d).FirstOrDefault();
                if (delete != null)
                {
                    this.context.tbl_studentlistpage.Remove(delete);

                    this.context.SaveChanges();
                }
                this.context.SaveChanges();
                return responseResult.GetResponse(true, null, "Removed successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return responseResult.GetResponse(false, null, "Cannot removed");
        }

        public async Task<ResponseResult> StudentListMaintenance(StudentListEntity StudentInfo, long UserID, bool isUpdate)
        {
            tbl_studentlistpage sinfo = new tbl_studentlistpage();
            if (!CheckStudentListExist(StudentInfo.Studentname, StudentInfo.Studentid).Result)
            {
                //After clicking on edit button this code is called 
                if (isUpdate)
                {
                    sinfo = this.context.tbl_studentlistpage.Where(a => a.Studentid == StudentInfo.Studentid).FirstOrDefault();
                    if (sinfo == null)
                    {
                        return responseResult.GetResponse(false, null, "Edit is succesfull");
                    }
                }
                //Save method for new entry
                else
                {
                    sinfo.Studentid = StudentInfo.Studentid;
                    sinfo.Studentname = StudentInfo.Studentname;
                    sinfo.Address = StudentInfo.Address;
                    sinfo.Cid = StudentInfo.Cid;
                    sinfo.Country = StudentInfo.Country;
                    sinfo.Sid = StudentInfo.Sid;
                    sinfo.State = StudentInfo.State;
                    sinfo.Cityid = StudentInfo.Cityid;
                    sinfo.City = StudentInfo.City;
                    sinfo.Pincode = StudentInfo.Pincode;
                    sinfo.DOB = StudentInfo.DOB;
                    sinfo.PhoneNumber = StudentInfo.PhoneNumber;
                    sinfo.Emailid = StudentInfo.Emailid;
                    sinfo.Courseid = StudentInfo.Courseid;
                    sinfo.Coursename = StudentInfo.Coursename;
                    sinfo.Classid = StudentInfo.Classid;
                    sinfo.Classname = StudentInfo.Classname;
                    sinfo.Subjectid = StudentInfo.Subjectid;
                    sinfo.Subjectname = StudentInfo.Subjectname;
                    sinfo.trans_id = this.AddTransactionData(StudentInfo.transaction);
                }
                sinfo.Studentid = StudentInfo.Studentid;
                sinfo.Studentname = StudentInfo.Studentname;
                sinfo.Address = StudentInfo.Address;
                sinfo.Cid = StudentInfo.Cid;
                sinfo.Country = StudentInfo.Country;
                sinfo.Sid = StudentInfo.Sid;
                sinfo.State = StudentInfo.State;
                sinfo.Cityid = StudentInfo.Cityid;
                sinfo.City = StudentInfo.City;
                sinfo.Pincode = StudentInfo.Pincode;
                sinfo.DOB = StudentInfo.DOB;
                sinfo.PhoneNumber = StudentInfo.PhoneNumber;
                sinfo.Emailid = StudentInfo.Emailid;
                sinfo.Courseid = StudentInfo.Courseid;
                sinfo.Coursename = StudentInfo.Coursename;
                sinfo.Classid = StudentInfo.Classid;
                sinfo.Classname = StudentInfo.Classname;
                sinfo.Subjectid = StudentInfo.Subjectid;
                sinfo.Subjectname = StudentInfo.Subjectname;
                sinfo.trans_id = this.AddTransactionData(StudentInfo.transaction);
                if (!isUpdate)
                {
                    this.context.tbl_studentlistpage.Add(sinfo);
                }
                var result = this.context.SaveChanges();
                if (result > 0)
                {
                    return responseResult.GetResponse(true, null, "StudentInformation Inserted Successfully!");
                }

                return responseResult.GetResponse(false, null, "An unexpected error occcurred while processing request!");
            }
            //Cannot duplicate the same name
            else
            {
                return responseResult.GetResponse(false, null, "StudentInformation already Exists");
            }
        }
    }
}