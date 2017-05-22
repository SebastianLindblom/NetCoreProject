using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudburryNet.Models.BlogViewModels
{
    public class Wall_ViewModel
    {
        public List<Data.DataModels.UserRelatedPost> UserFavoured { get; set; }
        public Data.DataModels.User SelectedUser { get; set; }
        public List<Data.DataModels.Post> Posts { get; set; }
        public List<Data.DataModels.Category> Categories { get; set; }
        public List<Data.DataModels.Category> Tags { get; set; }
    }
}
