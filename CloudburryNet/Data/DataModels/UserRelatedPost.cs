using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudburryNet.Data.DataModels
{
    public class UserRelatedPost
    {
        [Key]
        public int? Id { get; set; }
        public string RelationType { get; set; }
        public int? UserPostId { get; set; }

        public virtual UserPost UserPost { get; set; }
    }
}
