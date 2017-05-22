using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudburryNet.Data.DataModels
{
    public class User
    {
        [Key]
        public int? Id { get; set; }
        public string Alias { get; set; }
        public string Avatar { get; set; }

        public string AspNetUsersId { get; set; }

        public virtual ICollection<UserCategory> UserCategories { get; set; }
        public virtual ICollection<UserPost> UserPosts { get; set; }
        public virtual ICollection<UserTag> UserTagss { get; set; }
        public virtual ICollection<UserTheme> UserThemes { get; set; }
    }
}
