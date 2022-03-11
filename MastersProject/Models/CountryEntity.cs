using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MastersProject.Models.StateEntity;

namespace MastersProject.Models
{
    public class CountryEntity
    {
        public long Cid { get; set; }
        public string Cname { get; set; }
        //public long trans_id { get; set; }
        public List<CountryEntity> CountryInfo { get; set; } = new List<CountryEntity>();
        public virtual TransactionEntity transaction { get; set; }
        //public virtual ICollection<StateEntity> state { get; set; }
       
        
    }
    
}