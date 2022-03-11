using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MastersProject.Models.StateEntity;

namespace MastersProject.Models
{
    public class CityEntity
    {
        public long Cityid { get; set; }
        public string Cityname { get; set; }
        public long Sid { get; set; }
        public long Cid { get; set; }
        //public long trans_id { get; set; }
        public long country_dlt_id { get; set; }
        public long state_dlt_id { get; set; }
        public CountryEntity countryEntity { get; set; }
        public StateEntity stateEntity { get; set; }
        public virtual TransactionEntity transaction { get; set; }
        //public virtual StateEntity state { get; set; }
        //public virtual CountryEntity Country { get; set; }
        public List<CityEntity> CityInfo { get; set; } = new List<CityEntity>();
        
    }
}