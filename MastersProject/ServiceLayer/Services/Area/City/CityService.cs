using MastersProject.DataAccessLayer;
using MastersProject.DataAccessLayer.Area.City;
using MastersProject.Models;
using MastersProject.ServiceLayer.ServiceInterface.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MastersProject.ServiceLayer.Services.Area.City
{
    public class CityService : ICityService
    {
        private readonly ICity _cityContext;
        public CityService(ICity cityContext)
        {
            this._cityContext = cityContext;
        }
        public async Task<bool> CheckCityExist(string Cityname, long Cityid)
        {
            try
            {
                return await _cityContext.CheckCityExist(Cityname, Cityid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseResult> CityMaintenance(CityEntity CityInfo, long UserID, bool isUpdate)
        {
            try
            {
                return await _cityContext.CityMaintenance(CityInfo, UserID, isUpdate);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CityEntity>> GeAllCity()
        {
            try
            {
                return await _cityContext.GeAllCity();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<CityEntity>> GetAllCitybyCountry(long Sid)
        {
            try
            {
                return await _cityContext.GetAllCitybyCountry(Sid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CityEntity> GetCitybyid(long City)
        {
            try
            {
                return await _cityContext.GetCitybyid(City);
            }
            catch(Exception ex) 
            {
                throw ex;

            }
        }

        public async Task<ResponseResult> RemoveCity(long Cityid)
        {
            try
            {
                return await _cityContext.RemoveCity(Cityid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}