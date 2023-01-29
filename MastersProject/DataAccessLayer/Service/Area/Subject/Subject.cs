using MastersProject.DataAccessLayer.Area.Subject;
using MastersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MastersProject.DataAccessLayer.Service.Area.Subject
{
    public class Subject : ModelAccess, ISubject
    {
        Master_MVCEntities1 db = new Master_MVCEntities1();

        private ResponseResult responseResult;
        public Subject()
        {
            responseResult = new ResponseResult();
        }
        public async Task<bool> CheckSubjectExist(string Subjectname, long Subjectid)
        {
            bool isExists = this.context.tbl_subject.Where(x => (Subjectid == 0 || x.Subjectid != Subjectid) && x.Subjectname.ToLower() == Subjectname.ToLower()).FirstOrDefault() != null;
            return isExists;
        }

        public async Task<List<SubjectEntity>> GeAllSubject()
        {
            var SubjectInfo = (from u in this.context.tbl_subject
                            select new SubjectEntity()
                            {
                                Subjectid = u.Subjectid,
                                Subjectname = u.Subjectname,
                                courseEntity = new CourseEntity()
                                {
                                    Courseid = u.Courseid,
                                    Coursename = u.tbl_class.tbl_course.Coursename
                                },
                                classEntity = new ClassEntity()
                                {
                                    Classid = u.Classid,
                                    Classname = u.tbl_class.Classname
                                }
                            }).ToList();
            return SubjectInfo;
        }
        public async Task<List<SubjectEntity>> GetAllSubjectbyCourse(long Classid)
        {
            long  ClassID = 0;            
            var sdata = this.context.tbl_class.Where(x => x.Classid == Classid).FirstOrDefault();
            ClassID = sdata == null ? ClassID : sdata.Classid;
            var data = (from u in this.context.tbl_subject
                        orderby u.Subjectid descending
                        where u.Classid == ClassID
                        select new SubjectEntity()
                        {
                            Subjectid = u.Subjectid,
                            Subjectname = u.Subjectname,
                            transaction = new TransactionEntity() { trans_id = u.trans_id },
                        }).OrderByDescending(a => a.Subjectid).ToList();
            return data;
        }

        public async Task<SubjectEntity> GetSubjectbyid(long Subject)
        {
            SubjectEntity subjectEntity = new SubjectEntity();
            var cinfo = this.context.tbl_subject.Where(a => a.Subjectid == Subject).FirstOrDefault();
            if (cinfo != null)
            {
                subjectEntity.Subjectid = cinfo.Subjectid;
                subjectEntity.Subjectname = cinfo.Subjectname;
                subjectEntity.Courseid = cinfo.Courseid;
                //cityEntity.countryEntity.Cname = cinfo.tbl_state.tbl_country.Cname;
                subjectEntity.Classid = cinfo.Classid;
                //cityEntity.stateEntity.Sname = cinfo.tbl_state.Sname;
            }
            return subjectEntity;
        }

        public async Task<ResponseResult> RemoveSubject(long Subjectid)
        {
            try
            {
                var delete = (from d in this.context.tbl_subject
                              where d.Subjectid == Subjectid
                              select d).FirstOrDefault();
                if (delete != null)
                {
                    this.context.tbl_subject.Remove(delete);

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

        public async Task<ResponseResult> SubjectMaintenance(SubjectEntity SubjectInfo, long UserID, bool isUpdate)
        {
            tbl_subject cinfo = new tbl_subject();
            if (!CheckSubjectExist(SubjectInfo.Subjectname, SubjectInfo.Subjectid).Result)
            {
                if (isUpdate)
                {
                    cinfo = this.context.tbl_subject.Where(a => a.Subjectid == SubjectInfo.Subjectid).FirstOrDefault();
                    if (cinfo == null)
                    {
                        return responseResult.GetResponse(false, null, "Edit is succesfull");
                    }
                }
                else
                {
                    cinfo.Subjectname = SubjectInfo.Subjectname;
                    cinfo.trans_id = this.AddTransactionData(SubjectInfo.transaction);

                }
                cinfo.Subjectname = SubjectInfo.Subjectname;
                cinfo.trans_id = this.AddTransactionData(SubjectInfo.transaction);
                cinfo.Courseid = SubjectInfo.Courseid;
                cinfo.Classid = SubjectInfo.Classid;
                if (!isUpdate)
                {
                    this.context.tbl_subject.Add(cinfo);
                }
                var result = this.context.SaveChanges();
                if (result > 0)
                {
                    return responseResult.GetResponse(true, null, "Subject Inserted Successfully!");
                }

                return responseResult.GetResponse(false, null, "An unexpected error occcurred while processing request!");
            }
            else
            {
                return responseResult.GetResponse(false, null, "Subject name already Exists");
            }
        }
    }
}