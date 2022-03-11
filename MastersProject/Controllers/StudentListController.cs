using MastersProject.Common;
using MastersProject.DataAccessLayer;
using MastersProject.Models;
using MastersProject.ServiceLayer.ServiceInterface.StudentList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MastersProject.Controllers
{
    public class StudentListController : BaseController
    {
        private readonly IStudentListService _studentService;

        public ResponseResult res = new ResponseResult();

        public StudentListController(IStudentListService studentService)
        {
            _studentService = studentService;
        }
        // GET: StudentList
        public async Task<ActionResult> Index(int Studentid = 0)
        {
            StudentListEntity s = new StudentListEntity();
            var data = await _studentService.GeAllStudent();
            s.StudentInfo = new List<StudentListEntity>();
            if (Studentid > 0)
            {
                var info = await _studentService.GetStudentbyid(Studentid);
                if (info.Studentid > 0)
                {
                    s = info;
                }
            }
            if (data?.Count > 0)
            {
                s.StudentInfo = data;
            }
            return View(s);
        }
        public async Task<ActionResult> MainPageView()
        {
            var Data = await _studentService.GeAllStudent();
            if (Data == null)
            {
                List<StudentListEntity> sgroup = new List<StudentListEntity>();
                return View(sgroup);
            }
            return View(Data);
        }
        public async Task<ActionResult> StudentListMaintenance(long Studentid = 0)
        {

            StudentListEntity c = new StudentListEntity();
            if (Studentid > 0)
            {
                var result = await _studentService.GetStudentbyid((int)Studentid);

            }
            c.StudentInfo = new List<StudentListEntity>();

            return View("Index", Studentid);
        }
        [HttpPost]
        public async Task<ActionResult> SaveStudent(StudentListEntity c)
        {
            c.transaction = GetTransactionData(c.Courseid > 0 ? Enums.TransactionType.Update : Enums.TransactionType.Insert);
            res = await _studentService.StudentListMaintenance(c, SessionContext.Instance.LoginUser.UserID, c.Studentid > 0);
            res.RedirectURL = "StudentList/MainPageView";
            return Json(res);
        }


        [HttpPost]
        public async Task<JsonResult> RemoveStudentList(long Studentid)
        {
            var result = await _studentService.RemoveStudentList(Studentid);
            result.RedirectURL = "StudentList/MainPageView";
            return Json(result);
        }

        public async Task<JsonResult> StudentListData(long Studentid = 0)
        {
            var StudentListData = await _studentService.GetStudentbyid((int)Studentid);
            return Json(StudentListData);
        }

        public async Task<JsonResult> GeAllStudent()
        {
            var data = await _studentService.GeAllStudent();
            return Json(data);

        }
    }
}