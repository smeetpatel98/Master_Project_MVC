using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MastersProject.Models
{
    public class loginEntity
    {
        public long UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        //public Nullable<long> trans_id { get; set; }

        //public virtual TransactionEntity transaction { get; set; }
        //public string LoginErrorMessage { get; internal set; }
    }
}