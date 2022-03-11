using MastersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static MastersProject.Common.Common;
using static MastersProject.Models.StateEntity;

namespace MastersProject.DataAccessLayer.Area
{
    public interface IState
    {
        Task<bool> CheckStateExist(string Sname, long Sid);
        Task<ResponseResult> StateMaintenance(StateEntity StateInfo, long UserID, bool isUpdate);
        Task<List<StateEntity>> GetAllState();
        Task<ResponseResult> RemoveState(long Sid);
        Task<StateEntity> GetStateByID(int State);
        Task<List<StateEntity>> GetAllStatebyCountry(long Cid);


    }
}