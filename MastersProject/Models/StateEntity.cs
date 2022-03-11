using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MastersProject.Models
{
    public class StateEntity
    {
        public long Sid { get; set; }
        public string Sname { get; set; }
        public long Cid { get; set; }
        public long trans_id { get; set; }
        public long country_dlt_id { get; set; }
        
        public List<StateEntity> StateInfo { get; set; } = new List<StateEntity>();
        //public List<CountryEntity> CountryInfo { get; set; } = new List<CountryEntity>();
        public CountryEntity countryEntity { get; set; }


            /*public virtual CountryEntity country { get; set; */
            public virtual TransactionEntity transaction { get; set; }
            //public virtual ICollection<tbl_city> city { get; set; }
        
    }
}