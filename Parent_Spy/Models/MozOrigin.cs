using System;
using System.Collections.Generic;

#nullable disable

namespace Parent_Spy.Models
{
    public partial class MozOrigin
    {
        public MozOrigin()
        {
            MozPlaces = new HashSet<MozPlace>();
        }

        public long Id { get; set; }
        public string Prefix { get; set; }
        public string Host { get; set; }
        public long Frecency { get; set; }

        public virtual ICollection<MozPlace> MozPlaces { get; set; }
    }
}
