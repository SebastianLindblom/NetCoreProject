using System;
using System.Collections.Generic;

namespace Gwenzig.Data.DataModels
{
    public partial class AuthorityLevels
    {
        public AuthorityLevels()
        {
            Pages = new HashSet<Pages>();
            UserSettings = new HashSet<UserSettings>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string AccessLevel { get; set; }

        public virtual ICollection<Pages> Pages { get; set; }
        public virtual ICollection<UserSettings> UserSettings { get; set; }
    }
}
