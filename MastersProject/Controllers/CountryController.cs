using MastersProject.Models;
using MastersProject.ServiceLayer.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MastersProject.Controllers;
using MastersProject.DataAccessLayer;
using MastersProject.Common;

namespace MastersProject.Controllers
{
    public class CountryController : BaseController
    {
        private readonly ICountryService _countryService;

        public ResponseResult res = new ResponseResult();
       
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        // GET: Country
        public async Task<ActionResult> Index(int Cid = 0)
        {          
            CountryEntity country = new CountryEntity();
            var data = await _countryService.GetAllCountry();
            country.CountryInfo = new List<CountryEntity>();
            if (Cid > 0)
            {
                var info = await _countryService.GetCountryByID(Cid);
                if (info.Cid > 0)
                {
                    country = info;
                }
            }
            if (data?.Count > 0)
            {
                country.CountryInfo = data;
            }
            return View(country);
        }
        public async Task<ActionResult> CountryMaintenance(long Cid = 0)
        {
            
            CountryEntity country = new CountryEntity();
            if (Cid > 0)
            {
                var result = await _countryService.GetCountryByID((int)Cid);
                
            }
            country.CountryInfo = new List<CountryEntity>();

            return View("Index", Cid);
        }
        [HttpPost]
        public async Task <ActionResult> SaveCountry(CountryEntity c)
        {
            c.transaction = GetTransactionData(c.Cid > 0 ? Enums.TransactionType.Update : Enums.TransactionType.Insert);                     
            res = await _countryService.CountryMaintenance(c, SessionContext.Instance.LoginUser.UserID, c.Cid > 0);
            res.RedirectURL = "Country/Index";
            return Json(res);
        }
        [HttpPost]
        public async Task<JsonResult> DeleteCountry(long Cid)
        {
            var result = await _countryService.DeleteCountry(Cid);
            result.RedirectURL = "Country/Index";
            return Json(result);
        }

        public async Task<JsonResult> CountryData(long Cid = 0)
        {
            var CountryData = await _countryService.GetCountryByID((int)Cid);
            return Json(CountryData);
        }

        public async Task<JsonResult> GetAllCountry()
        {
            var data = await _countryService.GetAllCountry();
            return Json(data);
              
        }
    }
}