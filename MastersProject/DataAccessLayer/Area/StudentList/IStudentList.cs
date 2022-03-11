using MastersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MastersProject.DataAccessLayer.Area.StudentList
{
    public interface IStudentList
    {
        Task<bool> CheckStudentListExist(string Studentname, long Studentid);
        Task<ResponseResult> StudentListMaintenance(StudentListEntity StudentInfo, long UserID, bool isUpdate);
        Task<List<StudentListEntity>> GeAllStudent();
        Task<ResponseResult> RemoveStudentList(long Studentid);
        Task<StudentListEntity> GetStudentbyid(long Student);
    }
}