using MastersProject.Common;
using MastersProject.DataAccessLayer;
using MastersProject.Models;
using MastersProject.ServiceLayer.ServiceInterface.State;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

using System.Web.Mvc;

namespace MastersProject.Controllers
{
    public class StateController : BaseController
    {
        private readonly IStateService _stateService;

        public ResponseResult res = new ResponseResult();

        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }
        // GET: State
        public async Task<ActionResult> Index(int Sid =0)
        {
            StateEntity state = new StateEntity();
            var data = await _stateService.GetAllState();
            state.StateInfo = new List<StateEntity>();
            if(Sid> 0)
            {
                var info = await _stateService.GetStateByID(Sid);             
                if (info.Sid > 0)
                {
                    state = info; 
                }
            }
            if (data?.Count > 0)
            {
                state.StateInfo = data;
            }
            return View(state);
        }
        public async Task<ActionResult> StateMaintenance(long Sid = 0)
        {
            StateEntity state = new StateEntity();
            if (Sid > 0)
            {
                var result = await _stateService.GetStateByID((int)Sid);
            }
            state.StateInfo = new List<StateEntity>();
            return View("Index", Sid);
        }
        [HttpPost]
        public async Task<ActionResult> SaveState(StateEntity s)
        {
            s.transaction = GetTransactionData(s.Sid > 0 ? Enums.TransactionType.Update : Enums.TransactionType.Insert);
            res = await _stateService.StateMaintenance(s, SessionContext.Instance.LoginUser.UserID, s.Sid > 0);
            res.RedirectURL = "State/Index";
            return Json(res);
        }
        [HttpPost]
        public async Task<JsonResult> RemoveState(long Sid)
        {
            var result = await _stateService.RemoveState(Sid);
            result.RedirectURL = "State/Index";
            return Json(result);
        }
        public async Task<JsonResult> GetAllState()
        {
            var data = await _stateService.GetAllState();
            return Json(data);
        }

        public async Task<JsonResult> StateData(long Sid = 0)
        {
            var StateData = await _stateService.GetStateByID((int)Sid);
            return Json(StateData);
        }
        public async Task<JsonResult> StateeData(long Cid =0)
        {
            var sdata = await _stateService.GetAllStatebyCountry(Cid);
            return Json(sdata);
        }

    }
}