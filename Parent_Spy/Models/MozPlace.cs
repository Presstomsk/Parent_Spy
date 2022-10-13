using System;
using System.Collections.Generic;

#nullable disable

namespace Parent_Spy.Models
{
    public partial class MozPlace
    {
        public MozPlace()
        {
            MozAnnos = new HashSet<MozAnno>();
        }

        public long Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string RevHost { get; set; }
        public long? VisitCount { get; set; }
        public long Hidden { get; set; }
        public long Typed { get; set; }
        public long Frecency { get; set; }
        public long? LastVisitDate { get; set; }
        public string Guid { get; set; }
        public long ForeignCount { get; set; }
        public long UrlHash { get; set; }
        public string Description { get; set; }
        public string PreviewImageUrl { get; set; }
        public string SiteName { get; set; }
        public long? OriginId { get; set; }

        public virtual MozOrigin Origin { get; set; }
        public virtual ICollection<MozAnno> MozAnnos { get; set; }
    }
}
