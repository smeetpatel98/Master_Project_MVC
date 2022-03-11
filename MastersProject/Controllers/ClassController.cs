using MastersProject.Common;
using MastersProject.DataAccessLayer;
using MastersProject.Models;
using MastersProject.ServiceLayer.ServiceInterface.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MastersProject.Controllers
{
    public class ClassController : BaseController
    {
        private readonly IClassService _classService;

        public ResponseResult res = new ResponseResult();

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }
        // GET: Class
        public async Task<ActionResult> Index(int Classid = 0)
        {
            ClassEntity classs = new ClassEntity();
            var data = await _classService.GetAllClass();
            classs.ClassInfo = new List<ClassEntity>();
            if (Classid > 0)
            {
                var info = await _classService.GetClassByID(Classid);
                if (info.Classid > 0)
                {
                    classs = info;
                }
            }
            if (data?.Count > 0)
            {
                classs.ClassInfo = data;
            }
            return View(classs);
        }
        public async Task<ActionResult> ClassMaintenance(long Classid = 0)
        {
            ClassEntity c = new ClassEntity();
            if (Classid > 0)
            {
                var result = await _classService.GetClassByID((int)Classid);
            }
            c.ClassInfo = new List<ClassEntity>();
            return View("Index", Classid);
        }
        [HttpPost]
        public async Task<ActionResult> SaveClass(ClassEntity s)
        {
            s.transaction = GetTransactionData(s.Classid > 0 ? Enums.TransactionType.Update : Enums.TransactionType.Insert);
            res = await _classService.ClassMaintenance(s, SessionContext.Instance.LoginUser.UserID, s.Classid > 0);
            res.RedirectURL = "Class/Index";
            return Json(res);
        }
        [HttpPost]
        public async Task<JsonResult> RemoveClass(long Classid)
        {
            var result = await _classService.RemoveClass(Classid);
            result.RedirectURL = "Class/Index";
            return Json(result);
        }
        public async Task<JsonResult> GetAllClass()
        {
            var data = await _classService.GetAllClass();
            return Json(data);
        }

        public async Task<JsonResult> ClassData(long Classid = 0)
        {
            var ClassData = await _classService.GetClassByID((int)Classid);
            return Json(ClassData);
        }
        public async Task<JsonResult> cdata(long courseid = 0)
        {
            var cdata = await _classService.GetAllClassbyCourse(courseid);
            return Json(cdata);
        }
    }
}