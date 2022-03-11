using MastersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MastersProject.DataAccessLayer.Area.Class
{
    public interface IClass
    {
        Task<bool> CheckClassExist(string Classname, long Classid);
        Task<ResponseResult> ClassMaintenance(ClassEntity ClassInfo, long UserID, bool isUpdate);
        Task<List<ClassEntity>> GetAllClass();
        Task<ResponseResult> RemoveClass(long Classid);
        Task<ClassEntity> GetClassByID(int Class);
        Task<List<ClassEntity>> GetAllClassbyCourse(long Courseid);
    }
}