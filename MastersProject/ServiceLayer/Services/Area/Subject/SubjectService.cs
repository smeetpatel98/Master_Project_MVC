using MastersProject.DataAccessLayer;
using MastersProject.DataAccessLayer.Area.Subject;
using MastersProject.Models;
using MastersProject.ServiceLayer.ServiceInterface.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MastersProject.ServiceLayer.Services.Area.Subject
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubject _subjectcontext;
        public SubjectService(ISubject subjectContext)
        {
            this._subjectcontext = subjectContext;
        }
        public async Task<bool> CheckSubjectExist(string Subjectname, long Subjectid)
        {
            try
            {
                return await _subjectcontext.CheckSubjectExist(Subjectname, Subjectid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SubjectEntity>> GeAllSubject()
        {
            try
            {
                return await _subjectcontext.GeAllSubject();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<SubjectEntity>> GetAllSubjectbyCourse(long Classid)
        {
            try
            {
                return await _subjectcontext.GetAllSubjectbyCourse(Classid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SubjectEntity> GetSubjectbyid(long Subject)
        {
            try
            {
                return await _subjectcontext.GetSubjectbyid(Subject);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public  async Task<ResponseResult> RemoveSubject(long Subjectid)
        {
            try
            {
                return await _subjectcontext.RemoveSubject(Subjectid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseResult> SubjectMaintenance(SubjectEntity SubjectInfo, long UserID, bool isUpdate)
        {
            try
            {
                return await _subjectcontext.SubjectMaintenance(SubjectInfo, UserID, isUpdate);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}