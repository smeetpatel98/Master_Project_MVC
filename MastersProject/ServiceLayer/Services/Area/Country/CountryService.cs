using MastersProject.DataAccessLayer;
using MastersProject.DataAccessLayer.Area;
using MastersProject.Models;
using MastersProject.ServiceLayer.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MastersProject.Common.Common;

namespace MastersProject.ServiceLayer.Services.Area
{
    public class CountryService : ICountryService

    {
        private readonly ICountry _countryContext;
        public CountryService(ICountry countryContext)
        {
            this._countryContext = countryContext;
        }

        public async Task<bool> CheckCountryExist(string Cname, long Cid)
        {
            try
            {
                return await _countryContext.CheckCountryExist(Cname, Cid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseResult> CountryMaintenance(CountryEntity Countryinfo, long UserID, bool isUpdate)
        {
            try
            {
                return await _countryContext.CountryMaintenance(Countryinfo, UserID, isUpdate);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task<ResponseResult> DeleteCountry(long Cid)
        {
            try
            {
                return _countryContext.DeleteCountry(Cid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<CountryEntity>> GetAllCountry()
        {
            try
            {
                return await _countryContext.GetAllCountry();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CountryEntity> GetCountryByID(int Country)
        {
            try
            {
                return await _countryContext.GetCountryByID(Country);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

  
        public Task<ResponseResult> SaveCountry(CountryEntity country, string Username, bool IsUpdate)
        {
            throw new NotImplementedException();
        }
    }
}