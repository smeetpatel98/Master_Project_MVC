using MastersProject.DataAccessLayer;
using MastersProject.DataAccessLayer.Area;
using MastersProject.Models;
using MastersProject.ServiceLayer.ServiceInterface.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MastersProject.ServiceLayer.Services.Area.State
{
    public class StateService : IStateService
    {
        private readonly IState _stateContext;
        public StateService(IState stateContext)
        {
            this._stateContext = stateContext;
        }
        public async Task<bool> CheckStateExist(string Sname, long Sid)
        {
            try
            {
                return await _stateContext.CheckStateExist(Sname, Sid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<StateEntity>> GetAllState()
        {
            try
            {
                return await _stateContext.GetAllState();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StateEntity> GetStateByID(int State)
        {
            try
            {
                return await _stateContext.GetStateByID(State);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<StateEntity>> GetAllStatebyCountry(long Cid)
        {
            try
            {
                return await _stateContext.GetAllStatebyCountry(Cid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseResult> RemoveState(long Sid)
        {
            try
            {
                return await _stateContext.RemoveState(Sid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseResult> StateMaintenance(StateEntity StateInfo, long UserID, bool isUpdate)
        {
            try
            {
                return await _stateContext.StateMaintenance(StateInfo, UserID, isUpdate);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}