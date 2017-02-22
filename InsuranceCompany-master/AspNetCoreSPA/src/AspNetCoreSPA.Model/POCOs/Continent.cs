using System;
using System.Collections.Generic;

namespace AspNetCoreSPA.Model.POCOs
{
    public partial class Continent
    {
        public Continent()
        {
            StateOfOrigin = new HashSet<StateOfOrigin>();
        }

        public int ContinentId { get; set; }
        public int? CoeffId { get; set; }
        public string ContinentNameEn { get; set; }
        public string ContinentNameSrb { get; set; }

        public virtual ICollection<StateOfOrigin> StateOfOrigin { get; set; }
        public virtual Coefficient Coeff { get; set; }
    }
}
