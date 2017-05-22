using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudburryNet.Data.DataModels
{
    public class Post
    {
        [Key]
        public int? Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Visible { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public string PostDate { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
