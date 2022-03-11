using MastersProject.DataAccessLayer;
using MastersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MastersProject.ServiceLayer.ServiceInterface.Course
{
    public interface ICourseService
    {
        Task<bool> CheckCourseExist(string Coursename, long Courseid);
        Task<ResponseResult> CourseMaintenance(CourseEntity CourseInfo, long UserID, bool isUpdate);
        Task<List<CourseEntity>> GetAllCourse();
        Task<ResponseResult> RemoveCourse(long Courseid);
        Task<CourseEntity> GetCourseByID(int Course);
    }
}