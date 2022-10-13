using System;
using System.Collections.Generic;

#nullable disable

namespace Parent_Spy.Models
{
    public partial class MozAnno
    {        
        public long Id { get; set; }
        public long PlaceId { get; set; }
        public long? AnnoAttributeId { get; set; }
        public string Content { get; set; }
        public long? Flags { get; set; }
        public long? Expiration { get; set; }
        public long? Type { get; set; }
        public long? DateAdded { get; set; }
        public long? LastModified { get; set; }
        public virtual MozPlace Place { get; set; }
    }
}
