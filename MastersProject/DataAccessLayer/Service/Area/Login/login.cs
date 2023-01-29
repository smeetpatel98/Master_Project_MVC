using MastersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace MastersProject.DataAccessLayer
{
    public class login:ModelAccess
    {
        public async Task<loginEntity> PopulateUser(string username, string password)
        {
            var userInfo =  (from u in this.context.tbl_login
                            where u.Username == username && u.Password == password
                            select new loginEntity()
                            {
                                UserID = u.UserID,
                                Username = u.Username,
                                Password = u.Password,
                            }).FirstOrDefault();

            return userInfo;
        }
    }
}