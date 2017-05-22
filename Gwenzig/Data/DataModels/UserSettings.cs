using System;
using System.Collections.Generic;

namespace Gwenzig.Data.DataModels
{
    public partial class UserSettings
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AuthorityLevel { get; set; }
        public string EmailAddress { get; set; }
        public int? MenuItemsId { get; set; }
        public int? AuthorityLevelsId { get; set; }
        public int? AuthorityLevelsId1 { get; set; }
        public int? MenuItemsId1 { get; set; }

        public virtual AuthorityLevels AuthorityLevelsId1Navigation { get; set; }
        public virtual MenuItems MenuItemsId1Navigation { get; set; }
    }
}
