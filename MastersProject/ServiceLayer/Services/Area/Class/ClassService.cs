using MastersProject.DataAccessLayer;
using MastersProject.DataAccessLayer.Area.Class;
using MastersProject.Models;
using MastersProject.ServiceLayer.ServiceInterface.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MastersProject.ServiceLayer.Services.Area.Class
{
    public class ClassService : IClassService
    {
        private readonly IClass _classContext;
        public ClassService(IClass classContext)
        {
            this._classContext = classContext;
        }
        public async Task<bool> CheckClassExist(string Classname, long Classid)
        {
            try
            {
                return await _classContext.CheckClassExist(Classname, Classid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseResult> ClassMaintenance(ClassEntity ClassInfo, long UserID, bool isUpdate)
        {
            try
            {
                return await _classContext.ClassMaintenance(ClassInfo,UserID,isUpdate);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ClassEntity>> GetAllClass()
        {
            try
            {
                return await _classContext.GetAllClass();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ClassEntity>> GetAllClassbyCourse(long Courseid)
        {
            try
            {
                return await _classContext.GetAllClassbyCourse(Courseid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClassEntity> GetClassByID(int Class)
        {
            try
            {
                return await _classContext.GetClassByID(Class);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseResult> RemoveClass(long Classid)
        {
            try
            {
                return await _classContext.RemoveClass(Classid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}