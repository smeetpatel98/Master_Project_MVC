using MastersProject.DataAccessLayer.Area.Class;
using MastersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MastersProject.DataAccessLayer.Service.Area.Class
{
    public class Class : ModelAccess, IClass
    {
        Master_MVCEntities db = new Master_MVCEntities();

        private ResponseResult responseResult;
        public Class()
        {
            responseResult = new ResponseResult();
        }
        public async Task<bool> CheckClassExist(string Classname, long Classid)
        {
            bool isExists = this.context.tbl_class.Where(x => (Classid == 0 || x.Classid != Classid) && x.Classname.ToLower() == Classname.ToLower()).FirstOrDefault() != null;
            return isExists;
        }

        public async Task<ResponseResult> ClassMaintenance(ClassEntity ClassInfo, long UserID, bool isUpdate)
        {
            tbl_class sinfo = new tbl_class();
            if (!CheckClassExist(ClassInfo.Classname, ClassInfo.Classid).Result)
            {
                //After clicking on edit button this code is called 
                if (isUpdate)
                {
                    sinfo = this.context.tbl_class.Where(a => a.Classid == ClassInfo.Classid).FirstOrDefault();
                    if (sinfo == null)
                    {
                        return responseResult.GetResponse(false, null, "Edit is succesfull");
                    }
                }
                //Save method for new entry
                else
                {
                    sinfo.Classname = ClassInfo.Classname;
                    sinfo.trans_id = this.AddTransactionData(ClassInfo.transaction);
                }
                sinfo.Classname = ClassInfo.Classname;
                sinfo.trans_id = this.AddTransactionData(ClassInfo.transaction);
                sinfo.Courseid = ClassInfo.Courseid;
                if (!isUpdate)
                {
                    this.context.tbl_class.Add(sinfo);
                }
                var result = this.context.SaveChanges();
                if (result > 0)
                {
                    return responseResult.GetResponse(true, null, "Class Inserted Successfully!");
                }

                return responseResult.GetResponse(false, null, "An unexpected error occcurred while processing request!");
            }
            //Cannot duplicate the same name
            else
            {
                return responseResult.GetResponse(false, null, "Class name already Exists");
            }
        }

        public async Task<List<ClassEntity>> GetAllClass()
        {
            //View all state and country
            var ClassInfo = (from u in this.context.tbl_class
                             select new ClassEntity()
                             {
                                 Classid = u.Classid,
                                 Classname = u.Classname,
                                 courseEntity = new CourseEntity()
                                 {
                                     Courseid = u.Courseid,
                                     Coursename = u.tbl_course.Coursename
                                 }
                             }).ToList();
            return ClassInfo;
        }
        public async Task<List<ClassEntity>> GetAllClassbyCourse(long Courseid)
        {
            long CourseID = 0;
            var cdata = this.context.tbl_course.Where(s => s.Courseid == Courseid).FirstOrDefault();
            CourseID = cdata == null ? CourseID : cdata.Courseid;
            var data = (from u in this.context.tbl_class
                        orderby u.Classid descending
                        where u.Courseid == CourseID
                        select new ClassEntity()
                        {
                            Classid = u.Classid,
                            Classname = u.Classname,
                            transaction = new TransactionEntity() { trans_id = u.trans_id },
                        }).OrderByDescending(a => a.Classid).ToList();
            return data;
        }

        public async Task<ClassEntity> GetClassByID(int Class)
        {
            //Edit code 
            ClassEntity classEntity = new ClassEntity();
            var sinfo = this.context.tbl_class.Where(a => a.Classid == Class).FirstOrDefault();
            if (sinfo != null)
            {
                classEntity.Classid = sinfo.Classid;
                classEntity.Classname = sinfo.Classname;
                classEntity.Courseid = sinfo.Courseid;
                //stateEntity.countryEntity.Cname = sinfo.tbl_country.Cname;
            }
            return classEntity;
        }

        public async Task<ResponseResult> RemoveClass(long Classid)
        {
            try
            {
                var delete = (from d in this.context.tbl_class
                              where d.Classid == Classid
                              select d).FirstOrDefault();
                if (delete != null)
                {
                    this.context.tbl_class.Remove(delete);

                    this.context.SaveChanges();
                }
                this.context.SaveChanges();
                return responseResult.GetResponse(true, null, "removed successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return responseResult.GetResponse(false, null, "cannot removed");
        }
    }
}