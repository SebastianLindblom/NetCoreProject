using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudburryNet.Data.DataModels
{
    public class UserPost
    {
        [Key]
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<UserRelatedPost> UserRelatedPosts { get; set; }
    }
}
