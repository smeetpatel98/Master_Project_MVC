using MastersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MastersProject.DataAccessLayer;


namespace MastersProject.ServiceLayer
{
    public class LoginService
    {
        private login loginrepo = new login();
        public async Task<loginEntity> PopulateUser(string Username, string Password)
        {
            try
            {
                return await loginrepo.PopulateUser(Username, Password);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}