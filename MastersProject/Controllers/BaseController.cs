using MastersProject.Common;
using MastersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MastersProject.Controllers
{
    public class BaseController : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SessionContext.Instance.LoginUser == null)
            {
                filterContext.Result = new RedirectResult("~/Login/Index");
            }
        }
        public TransactionEntity GetTransactionData(Enums.TransactionType transType)
        {
            if (transType == Enums.TransactionType.Insert)
            {
                return new TransactionEntity()
                {
                    Created_dt = DateTime.Now,
                    Created_id = SessionContext.Instance.LoginUser.UserID
                };
            }
            else
            {
                return new TransactionEntity()
                {
                    Last_mod_dt = DateTime.Now,
                    Last_mod_id = SessionContext.Instance.LoginUser.UserID
                };
            }
        }
    }
}