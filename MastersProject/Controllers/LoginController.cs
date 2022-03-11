using MastersProject.DataAccessLayer;
using MastersProject.Models;
using MastersProject.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MastersProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private LoginService userService = new LoginService();
        ResponseResult responseResult = new ResponseResult();
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<JsonResult> ValidateUser(loginEntity user)
        {

            var userInfo = await userService.PopulateUser(user.Username, user.Password);
            if (userInfo != null)
            {
                SessionContext.Instance.LoginUser = userInfo;

                if (SessionContext.Instance.LoginUser.UserID > 0)
                {
                    responseResult.RedirectURL = "Home/Index";
                    responseResult.Status = true;
                    responseResult.Message = "Login Successfully!!";
                }
            }
            else
            {
                responseResult.Status = false;
                responseResult.Message = "Invalid Username or Password!";
            }
            return Json(responseResult);
        }
    }
}
