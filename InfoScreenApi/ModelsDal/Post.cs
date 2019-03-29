using System;
using System.Collections.Generic;

namespace InfoScreenApi.ModelsDal
{
    public partial class Post
    {
        public long PostId { get; set; }
        public int PostTypeId { get; set; }
        public string Text { get; set; }
        public bool Featured { get; set; }
        public DateTime Created { get; set; }
        public bool? Active { get; set; }
        public string Headline { get; set; }
        public byte[] Image { get; set; }        
        public virtual PostType PostType { get; set; }
    }
}
