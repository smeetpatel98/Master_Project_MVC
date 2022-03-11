using MastersProject.Common;
using MastersProject.DataAccessLayer;
using MastersProject.Models;
using MastersProject.ServiceLayer.ServiceInterface.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MastersProject.Controllers
{
    public class SubjectController : BaseController
    {
        private readonly ISubjectService _subjectService;

        public ResponseResult res = new ResponseResult();

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        // GET: Subject
        public async Task<ActionResult> Index(int Subjectid = 0)
        {
            SubjectEntity subject = new SubjectEntity();
            var data = await _subjectService.GeAllSubject();
            subject.SubjectInfo = new List<SubjectEntity>();
            if (Subjectid > 0)
            {
                var info = await _subjectService.GetSubjectbyid(Subjectid);
                if (info.Subjectid > 0)
                {
                    subject = info;
                }
            }
            if (data?.Count > 0)
            {
                subject.SubjectInfo = data;
            }
            return View(subject);
        }
        [HttpPost]
        public async Task<ActionResult> SaveSubject(SubjectEntity s)
        {
            s.transaction = GetTransactionData(s.Subjectid > 0 ? Enums.TransactionType.Update : Enums.TransactionType.Insert);
            res = await _subjectService.SubjectMaintenance(s, SessionContext.Instance.LoginUser.UserID, s.Subjectid > 0);
            res.RedirectURL = "Subject/Index";
            return Json(res);
        }
        [HttpPost]
        public async Task<JsonResult> RemoveCity(long Subjectid)
        {
            var result = await _subjectService.RemoveSubject(Subjectid);
            result.RedirectURL = "Subject/Index";
            return Json(result);
        }
        public async Task<JsonResult> GeAllSubject()
        {
            var data = await _subjectService.GeAllSubject();
            return Json(data);
        }
        public async Task<JsonResult> Sdata(long classid)
        {
            var data = await _subjectService.GetAllSubjectbyCourse(classid);
            return Json(data);
        }
    }
}