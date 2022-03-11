using MastersProject.DataAccessLayer;
using MastersProject.DataAccessLayer.Area.Course;
using MastersProject.Models;
using MastersProject.ServiceLayer.ServiceInterface.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MastersProject.ServiceLayer.Services.Area.Course
{
    public class CourseService : ICourseService
    {
        private readonly ICourse _courseContext;
        public CourseService(ICourse courseContext)
        {
            this._courseContext = courseContext;
        }
        public async Task<bool> CheckCourseExist(string Coursename, long Courseid)
        {
            try
            {
                return await _courseContext.CheckCourseExist(Coursename, Courseid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseResult> CourseMaintenance(CourseEntity CourseInfo, long UserID, bool isUpdate)
        {
            try
            {
                return await _courseContext.CourseMaintenance(CourseInfo, UserID, isUpdate);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CourseEntity>> GetAllCourse()
        {
            try
            {
                return await _courseContext.GetAllCourse();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CourseEntity> GetCourseByID(int Course)
        {
            try
            {
                return await _courseContext.GetCourseByID(Course);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseResult> RemoveCourse(long Courseid)
        {
            try
            {
                return await _courseContext.RemoveCourse(Courseid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}