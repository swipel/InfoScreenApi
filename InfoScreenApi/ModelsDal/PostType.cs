using System;
using System.Collections.Generic;

namespace InfoScreenApi.ModelsDal
{
    public partial class PostType
    {
        public PostType()
        {
            Post = new HashSet<Post>();
        }

        public int PostTypeId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}
