using System;
using System.Collections.Generic;

namespace Gwenzig.Data.DataModels
{
    public partial class PageMenuBinders
    {
        public int Id { get; set; }
        public int? MenuItemsId { get; set; }
        public int? PagesId { get; set; }

        public virtual MenuItems MenuItems { get; set; }
        public virtual Pages Pages { get; set; }
    }
}
