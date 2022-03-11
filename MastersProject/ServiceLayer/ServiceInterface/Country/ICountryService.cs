using MastersProject.DataAccessLayer;
using MastersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static MastersProject.Common.Common;

namespace MastersProject.ServiceLayer.ServiceInterface
{
    public interface ICountryService
    {
        Task<ResponseResult> CountryMaintenance(CountryEntity Countryinfo, long UserID, bool isUpdate);
        Task<ResponseResult> SaveCountry(CountryEntity country, string Username, bool IsUpdate);
        Task<bool> CheckCountryExist(string Cname, long Cid);
        Task<List<CountryEntity>> GetAllCountry();
        Task<CountryEntity> GetCountryByID(int Country);
       Task<ResponseResult> DeleteCountry(long Cid);
        
    }
}