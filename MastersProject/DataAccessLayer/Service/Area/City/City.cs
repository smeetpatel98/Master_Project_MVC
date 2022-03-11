using MastersProject.DataAccessLayer.Area.City;
using MastersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MastersProject.DataAccessLayer.Service.Area.City
{
    public class City : ModelAccess, ICity
    {
        Master_MVCEntities db = new Master_MVCEntities();

        private ResponseResult responseResult;
        public City()
        {
            responseResult = new ResponseResult();
        }
        public async Task<bool> CheckCityExist(string Cityname, long Cityid)
        {
            bool isExists = this.context.tbl_city.Where(x => (Cityid == 0 || x.Cityid != Cityid) && x.Cityname.ToLower() == Cityname.ToLower()).FirstOrDefault() != null;
            return isExists;
        }

        public async Task<ResponseResult> CityMaintenance(CityEntity CityInfo, long UserID, bool isUpdate)
        {
            tbl_city cinfo = new tbl_city();
            if (!CheckCityExist(CityInfo.Cityname, CityInfo.Sid).Result)
            {
                if (isUpdate)
                {
                    cinfo = this.context.tbl_city.Where(a => a.Cityid == CityInfo.Cityid).FirstOrDefault();
                    if (cinfo == null)
                    {
                        return responseResult.GetResponse(false, null, "Edit is succesfull");
                    }
                }
                else
                {
                    cinfo.Cityname = CityInfo.Cityname;
                    cinfo.trans_id = this.AddTransactionData(CityInfo.transaction);

                }
                cinfo.Cityname = CityInfo.Cityname;
                cinfo.trans_id = this.AddTransactionData(CityInfo.transaction);
                cinfo.Cid = CityInfo.Cid;
                cinfo.Sid = CityInfo.Sid;
                if (!isUpdate)
                {
                    this.context.tbl_city.Add(cinfo);
                }
                var result = this.context.SaveChanges();
                if (result > 0)
                {
                    return responseResult.GetResponse(true, null, "City Inserted Successfully!");
                }

                return responseResult.GetResponse(false, null, "An unexpected error occcurred while processing request!");
            }
            else
            {
                return responseResult.GetResponse(false, null, "City name already Exists");
            }
        }

        public async Task<List<CityEntity>> GeAllCity()
        {
            var CityInfo = (from u in this.context.tbl_city
                             select new CityEntity()
                             {
                                 Cityid = u.Cityid,
                                 Cityname = u.Cityname,
                                 countryEntity = new CountryEntity()
                                 {
                                     Cid= u.Cid,
                                     Cname=u.tbl_state.tbl_country.Cname
                                 },
                                 stateEntity = new StateEntity()
                                 {
                                     Sid=u.Sid,
                                     Sname=u.tbl_state.Sname
                                 }
                             }).ToList();
            return CityInfo;
        }
        public async Task<List<CityEntity>> GetAllCitybyCountry(long Sid)
        {
            long SID = 0;            
            var sdata = this.context.tbl_state.Where(x => x.Sid == Sid).FirstOrDefault();
            SID = sdata == null ? SID : sdata.Sid;
            var data = (from u in this.context.tbl_city
                        orderby u.Cityid descending
                        where u.Sid == SID
                        select new CityEntity()
                        {
                            Cityid = u.Cityid,
                            Cityname = u.Cityname,
                            transaction= new TransactionEntity() { trans_id =u.trans_id},
                        }).OrderByDescending(a => a.Cityid).ToList();
            return data;
        }

        public async Task<CityEntity> GetCitybyid(long City)
        {
            CityEntity cityEntity = new CityEntity();
            var cinfo = this.context.tbl_city.Where(a => a.Cityid == City).FirstOrDefault();
            if (cinfo != null)
            {
                cityEntity.Cityid = cinfo.Cityid;
                cityEntity.Cityname = cinfo.Cityname;
                cityEntity.Cid = cinfo.Cid;
                //cityEntity.countryEntity.Cname = cinfo.tbl_state.tbl_country.Cname;
                cityEntity.Sid = cinfo.Sid;
                //cityEntity.stateEntity.Sname = cinfo.tbl_state.Sname;
            }
            return cityEntity;
        }

        public async Task<ResponseResult> RemoveCity(long Cityid)
        {
            try
            {
                var delete = (from d in this.context.tbl_city
                              where d.Cityid == Cityid
                              select d).FirstOrDefault();
                if (delete != null)
                {
                    this.context.tbl_city.Remove(delete);

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