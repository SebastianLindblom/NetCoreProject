using System;
using System.Collections.Generic;

namespace Gwenzig.Data.DataModels
{
    public partial class MenuItems
    {
        public MenuItems()
        {
            PageMenuBinders = new HashSet<PageMenuBinders>();
            UserSettings = new HashSet<UserSettings>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public int? MenuNavigationsId { get; set; }

        public virtual ICollection<PageMenuBinders> PageMenuBinders { get; set; }
        public virtual ICollection<UserSettings> UserSettings { get; set; }
        public virtual MenuNavigations MenuNavigations { get; set; }
    }
}
