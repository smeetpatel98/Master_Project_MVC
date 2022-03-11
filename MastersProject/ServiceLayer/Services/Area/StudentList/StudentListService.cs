using MastersProject.DataAccessLayer;
using MastersProject.DataAccessLayer.Area.StudentList;
using MastersProject.Models;
using MastersProject.ServiceLayer.ServiceInterface.StudentList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MastersProject.ServiceLayer.Services.Area.StudentList
{
    public class StudentListService : IStudentListService
    {
        private readonly IStudentList _studentcontext;
        public StudentListService(IStudentList studentContext)
        {
            this._studentcontext = studentContext;
        }

        public async Task<bool> CheckStudentListExist(string Studentname, long Studentid)
        {
            try
            {
                return await _studentcontext.CheckStudentListExist(Studentname, Studentid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<StudentListEntity>> GeAllStudent()
        {
            try
            {
                return await _studentcontext.GeAllStudent();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StudentListEntity> GetStudentbyid(long Student)
        {
            try
            {
                return await _studentcontext.GetStudentbyid(Student);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseResult> RemoveStudentList(long Studentid)
        {
            try
            {
                return await _studentcontext.RemoveStudentList(Studentid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseResult> StudentListMaintenance(StudentListEntity StudentInfo, long UserID, bool isUpdate)
        {
            try
            {
                return await _studentcontext.StudentListMaintenance(StudentInfo, UserID, isUpdate);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}