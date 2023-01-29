using MastersProject.DataAccessLayer.Area;
using MastersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MastersProject.DataAccessLayer.Service.Area.Country
{
    public class Country : ModelAccess, ICountry
    {
        Master_MVCEntities1 db = new Master_MVCEntities1();

        private ResponseResult responseResult;
        public Country()
        {
            responseResult = new ResponseResult();
        }

        public async Task<bool> CheckCountryExist(string Cname, long Cid)
        {
            bool isExists = this.context.tbl_country.Where(x => (Cid == 0 || x.Cid != Cid) && x.Cname.ToLower() == Cname.ToLower()).FirstOrDefault() != null;
            return isExists;
        }
        public async Task<ResponseResult> CountryMaintenance(CountryEntity Countryinfo, long UserID, bool isUpdate)
        {
            tbl_country cinfo = new tbl_country();
            if (!CheckCountryExist(Countryinfo.Cname, Countryinfo.Cid).Result)
            {
                if (isUpdate)
                {
                    cinfo = this.context.tbl_country.Where(a => a.Cid == Countryinfo.Cid).FirstOrDefault();
                    if (Countryinfo == null)
                    {
                        return responseResult.GetResponse(false, null, "Error while proccesing");
                    }
                }
                else
                {              
                    
                    cinfo.Cname = Countryinfo.Cname;
                    cinfo.trans_id = this.AddTransactionData(Countryinfo.transaction);
                }
                cinfo.Cname = Countryinfo.Cname;
                cinfo.trans_id = this.AddTransactionData(Countryinfo.transaction);
                if (!isUpdate)
                {
                    this.context.tbl_country.Add(cinfo);
                }
                var result = this.context.SaveChanges();
                if (result > 0)
                {
                    return responseResult.GetResponse(true, null, "Country Inserted Successfully!");                  
                }
                 
                return responseResult.GetResponse(false, null, "An unexpected error occcurred while processing request!");
            }
            else
            {
                return responseResult.GetResponse(false, null, "Country name already Exists");
            }

        }


        public async Task<ResponseResult> DeleteCountry(long Cid)
        {
            try
            {
                var delete = (from d in this.context.tbl_country
                              where d.Cid == Cid
                              select d).FirstOrDefault();
                if (delete != null)
                {
                    this.context.tbl_country.Remove(delete);
                    
                    this.context.SaveChanges();
                }
                this.context.SaveChanges();
                return responseResult.GetResponse(true, null, "removed successfully");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return responseResult.GetResponse(false, null, "cannot removed");
        }

        public async Task<List<CountryEntity>> GetAllCountry()
        {
            var CountryInfo = (from u in this.context.tbl_country

                            select new CountryEntity()
                            {

                                Cid = u.Cid,
                                Cname=u.Cname,

                            }).ToList();

            return CountryInfo;
        }

        public async Task<CountryEntity> GetCountryByID(int Country)
        {
            CountryEntity countryEntity = new CountryEntity();
            var cinfo = this.context.tbl_country.Where(a=>a.Cid== Country).FirstOrDefault();
            if(cinfo != null)
            {
                countryEntity.Cid = cinfo.Cid;
                countryEntity.Cname = cinfo.Cname;              
                
            }
            return countryEntity;
        }

        public Task<ResponseResult> SaveCountry(CountryEntity country, string Username, bool IsUpdate)
        {
            throw new NotImplementedException();
        }
    }
}