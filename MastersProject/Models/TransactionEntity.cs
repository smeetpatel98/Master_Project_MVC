using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MastersProject.Models.CityEntity;
using static MastersProject.Models.StateEntity;

namespace MastersProject.Models
{
    public class TransactionEntity
    {
        public long trans_id { get; set; }
        public System.DateTime Created_dt { get; set; }
        public Nullable<long> Created_id { get; set; }
        public Nullable<System.DateTime> Last_mod_dt { get; set; }
        public Nullable<long> Last_mod_id { get; set; }

        //public virtual ICollection<CityEntity> city { get; set; }
        //public virtual ICollection<CountryEntity> country { get; set; }
        //public virtual ICollection<tbl_login> tbl_login { get; set; }
        //public virtual ICollection<StateEntity> state { get; set; }
    }
}