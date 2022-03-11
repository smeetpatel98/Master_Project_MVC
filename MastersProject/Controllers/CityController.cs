using MastersProject.Common;
using MastersProject.DataAccessLayer;
using MastersProject.DataAccessLayer.Service.Area.City;
using MastersProject.Models;
using MastersProject.ServiceLayer.ServiceInterface.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MastersProject.Controllers
{
    public class CityController : BaseController
    {
        private readonly ICityService _cityService;

        public ResponseResult res = new ResponseResult();

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        // GET: City
        public async Task<ActionResult> Index(int Cityid=0)
        {
            CityEntity city = new CityEntity();
            var data = await _cityService.GeAllCity();
            city.CityInfo = new List<CityEntity>();
            if (Cityid > 0)
            {
                var info = await _cityService.GetCitybyid(Cityid);
                if (info.Cityid > 0)
                {
                    city = info;
                }
            }
            if (data?.Count > 0)
            {
                city.CityInfo = data;
            }
            return View(city);
        }
        [HttpPost]
        public async Task<ActionResult> SaveCity(CityEntity s)
        {
            s.transaction = GetTransactionData(s.Cityid > 0 ? Enums.TransactionType.Update : Enums.TransactionType.Insert);
            res = await _cityService.CityMaintenance(s, SessionContext.Instance.LoginUser.UserID, s.Cityid > 0);
            res.RedirectURL = "City/Index";
            return Json(res);
        }
        [HttpPost]
        public async Task<JsonResult> RemoveCity(long Cityid)
        {
            var result = await _cityService.RemoveCity(Cityid);
            result.RedirectURL = "City/Index";
            return Json(result);
        }
        public async Task<JsonResult> GeAllCity()
        {
            var data = await _cityService.GeAllCity();
            return Json(data);
        }

        public async Task<JsonResult> CityData(long Cid = 0)
        {
            var StateData = await _cityService.GetCitybyid((int)Cid);
            return Json(StateData);
        }
        public async Task<JsonResult> cdata(long Sid)
        {
            var data = await _cityService.GetAllCitybyCountry(Sid);
            return Json(data);
        }
    }
}