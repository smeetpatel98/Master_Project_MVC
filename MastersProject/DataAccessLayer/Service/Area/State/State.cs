using MastersProject.DataAccessLayer.Area;
using MastersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MastersProject.DataAccessLayer.Service.Area.State
{
    public class State : ModelAccess,IState
    {
        Master_MVCEntities db = new Master_MVCEntities();

        private ResponseResult responseResult;
        public State()
        {
            responseResult = new ResponseResult();
        }

        public async Task<bool> CheckStateExist(string Sname, long Sid)
        {    
            bool isExists = this.context.tbl_state.Where(x => (Sid == 0 || x.Sid != Sid) && x.Sname.ToLower() == Sname.ToLower()).FirstOrDefault() != null;
            return isExists;
        }

        public async Task<List<StateEntity>> GetAllState()
        {
            //View all state and country
            var StateInfo = (from u in this.context.tbl_state
                             select new StateEntity()
                             {
                                 Sid = u.Sid,
                                 Sname = u.Sname,
                                 countryEntity = new CountryEntity()
                                 {
                                     Cid = u.Cid,
                                     Cname = u.tbl_country.Cname
                                 }                                
                             }).ToList();
            return StateInfo;
        }
        public async Task<List<StateEntity>> GetAllStatebyCountry(long Cid)
        {
            long CID = 0;
            var cdata = this.context.tbl_country.Where(s => s.Cid == Cid).FirstOrDefault();
            CID = cdata == null ? CID : cdata.Cid;            
            var data = (from u in this.context.tbl_state
                        orderby u.Sid descending
                        where u.Cid == CID 
                        select new StateEntity()
                        {
                            Sid = u.Sid,
                            Sname = u.Sname,
                            transaction = new TransactionEntity() { trans_id = u.trans_id },
                        }).OrderByDescending(a =>a.Sid).ToList();
            return data;
        }

        public async Task<StateEntity> GetStateByID(int State)
        {
            //Edit code 
            StateEntity stateEntity = new StateEntity();
            var sinfo = this.context.tbl_state.Where(a => a.Sid == State).FirstOrDefault();
            if (sinfo != null)
            {
                stateEntity.Sid = sinfo.Sid;
                stateEntity.Sname = sinfo.Sname;
                stateEntity.Cid = sinfo.Cid;
                //stateEntity.countryEntity.Cname = sinfo.tbl_country.Cname;
            }
            return stateEntity;
        }

        public async Task<ResponseResult> RemoveState(long Sid)
        {
            try
            {
                var iExists = (from statetable in this.context.tbl_state
                               join countrytble in this.context.tbl_country
                               on statetable.Sid equals countrytble.Cid
                               where statetable.Sid == Sid
                               select new
                               {
                                   ig_id = countrytble.Cid
                               }).Any();
                if (!iExists)
                {
                    var StateInfo = (from s in this.context.tbl_state
                                     where s.Sid == Sid
                                     select s).FirstOrDefault();
                    if (StateInfo != null)
                    {
                        this.context.tbl_state.Remove(StateInfo);
                        this.context.SaveChanges();
                    }
                    this.context.SaveChanges();
                    return responseResult.GetResponse(true, null, "removed successfully");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return responseResult.GetResponse(false, null, "Cannot removed");
        }

        public async Task<ResponseResult> StateMaintenance(StateEntity StateInfo, long UserID, bool isUpdate)
        {
            tbl_state sinfo = new tbl_state();
            if (!CheckStateExist(StateInfo.Sname, StateInfo.Sid).Result)
            {
                //After clicking on edit button this code is called 
                if (isUpdate)
                {
                    sinfo = this.context.tbl_state.Where(a => a.Sid == StateInfo.Sid).FirstOrDefault();
                    if (sinfo == null)
                    {
                        return responseResult.GetResponse(false, null, "Edit is succesfull");
                    }
                }
                //Save method for new entry
                else
                {
                    sinfo.Sname = StateInfo.Sname;
                    sinfo.trans_id = this.AddTransactionData(StateInfo.transaction);
                }
                sinfo.Sname = StateInfo.Sname;
                sinfo.trans_id = this.AddTransactionData(StateInfo.transaction);
                sinfo.Cid = StateInfo.Cid;
                if (!isUpdate)
                {
                    this.context.tbl_state.Add(sinfo);
                }
                var result = this.context.SaveChanges();
                if (result > 0)
                {
                    return responseResult.GetResponse(true, null, "State Inserted Successfully!");
                }

                return responseResult.GetResponse(false, null, "An unexpected error occcurred while processing request!");
            }
            //Cannot duplicate the same name
            else
            {
                return responseResult.GetResponse(false, null, "State name already Exists");
            }
        }
    }
}