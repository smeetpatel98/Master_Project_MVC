using MastersProject.DataAccessLayer.Area.Course;
using MastersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MastersProject.DataAccessLayer.Service.Area.Course
{
    public class Course : ModelAccess, ICourse
    {
        Master_MVCEntities db = new Master_MVCEntities();

        private ResponseResult responseResult;
        public Course()
        {
            responseResult = new ResponseResult();
        }
        public async Task<bool> CheckCourseExist(string Coursename, long Courseid)
        {
            bool isExists = this.context.tbl_course.Where(x => (Courseid == 0 || x.Courseid != Courseid) && x.Coursename.ToLower() == Coursename.ToLower()).FirstOrDefault() != null;
            return isExists;
        }

        public async Task<ResponseResult> CourseMaintenance(CourseEntity CourseInfo, long UserID, bool isUpdate)
        {
            tbl_course cinfo = new tbl_course();
            if (!CheckCourseExist(CourseInfo.Coursename, CourseInfo.Courseid).Result)
            {
                if (isUpdate)
                {
                    cinfo = this.context.tbl_course.Where(a => a.Courseid == CourseInfo.Courseid).FirstOrDefault();
                    if (CourseInfo == null)
                    {
                        return responseResult.GetResponse(false, null, "Error while proccesing");
                    }
                }
                else
                {

                    cinfo.Coursename = CourseInfo.Coursename;
                    cinfo.trans_id = this.AddTransactionData(CourseInfo.transaction);
                }
                cinfo.Coursename = CourseInfo.Coursename;
                cinfo.trans_id = this.AddTransactionData(CourseInfo.transaction);
                if (!isUpdate)
                {
                    this.context.tbl_course.Add(cinfo);
                }
                var result = this.context.SaveChanges();
                if (result > 0)
                {
                    return responseResult.GetResponse(true, null, "Course Inserted Successfully!");
                }

                return responseResult.GetResponse(false, null, "An unexpected error occcurred while processing request!");
            }
            else
            {
                return responseResult.GetResponse(false, null, "Course name already Exists");
            }
        }

        public async Task<List<CourseEntity>> GetAllCourse()
        {
            var CourseInfo = (from u in this.context.tbl_course

                               select new CourseEntity()
                               {

                                   Courseid = u.Courseid,
                                   Coursename = u.Coursename,

                               }).ToList();

            return CourseInfo;
        }

        public async Task<CourseEntity> GetCourseByID(int Course)
        {
            CourseEntity courseEntity = new CourseEntity();
            var cinfo = this.context.tbl_course.Where(a => a.Courseid == Course).FirstOrDefault();
            if (cinfo != null)
            {
                courseEntity.Courseid = cinfo.Courseid;
                courseEntity.Coursename = cinfo.Coursename;

            }
            return courseEntity;
        }

        public async Task<ResponseResult> RemoveCourse(long Courseid)
        {
            try
            {
                var delete = (from d in this.context.tbl_course
                              where d.Courseid == Courseid
                              select d).FirstOrDefault();
                if (delete != null)
                {
                    this.context.tbl_course.Remove(delete);
                    this.context.SaveChanges();
                }
                this.context.SaveChanges();
                return responseResult.GetResponse(true, null, "removed successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return responseResult.GetResponse(false, null, "cannot removed");
        }
    }
}