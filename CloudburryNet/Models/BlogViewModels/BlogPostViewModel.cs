using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudburryNet.Models.BlogViewModels
{
    public class BlogOverviewViewModel
    {
        public List<Data.DataModels.UserRelatedPost> UserRelatedPosts { get; set; }
        public List<Data.DataModels.Post> UserCreatedPosts {get;set;}
    }

    public class BlogPostFactoryViewModel
    {
        public Data.DataModels.Post Post { get; set; }
        public Data.DataModels.Tag Tag { get; set; }
        public List<string> Tags { get; set; }

    }
}
