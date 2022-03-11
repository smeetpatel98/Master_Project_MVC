using MastersProject.Common;
using MastersProject.DataAccessLayer;
using MastersProject.Models;
using MastersProject.ServiceLayer.ServiceInterface.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MastersProject.Controllers
{
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;

        public ResponseResult res = new ResponseResult();

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        // GET: Course
        public async Task<ActionResult> Index(int Courseid = 0)
        {
            CourseEntity course = new CourseEntity();
            var data = await _courseService.GetAllCourse();
            course.CourseInfo = new List<CourseEntity>();
            if (Courseid > 0)
            {
                var info = await _courseService.GetCourseByID(Courseid);
                if (info.Courseid > 0)
                {
                    course = info;
                }
            }
            if (data?.Count > 0)
            {
                course.CourseInfo = data;
            }
            return View(course);
        }
        public async Task<ActionResult> CourseMaintenance(long Courseid = 0)
        {

            CourseEntity course = new CourseEntity();
            if (Courseid > 0)
            {
                var result = await _courseService.GetCourseByID((int)Courseid);

            }
            course.CourseInfo = new List<CourseEntity>();

            return View("Index", Courseid);
        }
        [HttpPost]
        public async Task<ActionResult> SaveCourse(CourseEntity c)
        {
            c.transaction = GetTransactionData(c.Courseid > 0 ? Enums.TransactionType.Update : Enums.TransactionType.Insert);
            res = await _courseService.CourseMaintenance(c, SessionContext.Instance.LoginUser.UserID, c.Courseid > 0);
            res.RedirectURL = "Course/Index";
            return Json(res);
        }


        [HttpPost]
        public async Task<JsonResult> RemoveCourse(long Courseid)
        {
            var result = await _courseService.RemoveCourse(Courseid);
            result.RedirectURL = "Course/Index";
            return Json(result);
        }

        public async Task<JsonResult> CourseData(long Courseid = 0)
        {
            var CourseData = await _courseService.GetCourseByID((int)Courseid);
            return Json(CourseData);
        }

        public async Task<JsonResult> GetAllCourse()
        {
            var data = await _courseService.GetAllCourse();
            return Json(data);

        }
    }
}