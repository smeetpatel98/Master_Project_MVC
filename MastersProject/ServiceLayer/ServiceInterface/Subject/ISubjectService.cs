using MastersProject.DataAccessLayer;
using MastersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MastersProject.ServiceLayer.ServiceInterface.Subject
{
    public interface ISubjectService
    {
        Task<bool> CheckSubjectExist(string Subjectname, long Subjectid);
        Task<ResponseResult> SubjectMaintenance(SubjectEntity SubjectInfo, long UserID, bool isUpdate);
        Task<List<SubjectEntity>> GeAllSubject();
        Task<ResponseResult> RemoveSubject(long Subjectid);
        Task<SubjectEntity> GetSubjectbyid(long Subject);
        Task<List<SubjectEntity>> GetAllSubjectbyCourse(long Classid);
    }
}