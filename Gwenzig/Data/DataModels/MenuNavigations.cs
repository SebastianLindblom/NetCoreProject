using System;
using System.Collections.Generic;

namespace Gwenzig.Data.DataModels
{
    public partial class MenuNavigations
    {
        public MenuNavigations()
        {
            MenuItems = new HashSet<MenuItems>();
        }

        public int Id { get; set; }
        public string Navigation { get; set; }
        public string Type { get; set; }
        public int? AppDataTypesId { get; set; }

        public virtual ICollection<MenuItems> MenuItems { get; set; }
        public virtual AppDataTypes AppDataTypes { get; set; }
    }
}
