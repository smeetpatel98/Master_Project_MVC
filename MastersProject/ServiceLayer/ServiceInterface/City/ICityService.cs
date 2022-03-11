using MastersProject.DataAccessLayer;
using MastersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MastersProject.ServiceLayer.ServiceInterface.City
{
    public interface ICityService
    {
        Task<bool> CheckCityExist(string Cityname, long Cityid);
        Task<ResponseResult> CityMaintenance(CityEntity CityInfo, long UserID, bool isUpdate);
        Task<List<CityEntity>> GeAllCity();
        Task<ResponseResult> RemoveCity(long Cityid);
        Task<CityEntity> GetCitybyid(long City);
        Task<List<CityEntity>> GetAllCitybyCountry(long Sid);
    }
}