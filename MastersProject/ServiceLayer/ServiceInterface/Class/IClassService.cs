using MastersProject.DataAccessLayer;
using MastersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MastersProject.ServiceLayer.ServiceInterface.Class
{
    public interface IClassService
    {
        Task<bool> CheckClassExist(string Classname, long Classid);
        Task<ResponseResult> ClassMaintenance(ClassEntity ClassInfo, long UserID, bool isUpdate);
        Task<List<ClassEntity>> GetAllClass();
        Task<ResponseResult> RemoveClass(long Classid);
        Task<ClassEntity> GetClassByID(int Class);
        Task<List<ClassEntity>> GetAllClassbyCourse(long Courseid);
    }
}