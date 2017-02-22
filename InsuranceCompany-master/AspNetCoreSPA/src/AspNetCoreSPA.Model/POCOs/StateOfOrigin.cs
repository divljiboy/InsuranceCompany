using System;
using System.Collections.Generic;

namespace AspNetCoreSPA.Model.POCOs
{
    public partial class StateOfOrigin
    {
        public StateOfOrigin()
        {
            Destination = new HashSet<Destination>();
        }

        public int StId { get; set; }
        public int ContinentId { get; set; }
        public string StNameSrb { get; set; }
        public string StNameEn { get; set; }

        public virtual ICollection<Destination> Destination { get; set; }
        public virtual Continent Continent { get; set; }
    }
}
