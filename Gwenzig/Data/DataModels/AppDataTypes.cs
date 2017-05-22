using System;
using System.Collections.Generic;

namespace Gwenzig.Data.DataModels
{
    public partial class AppDataTypes
    {
        public AppDataTypes()
        {
            MenuNavigations = new HashSet<MenuNavigations>();
        }

        public int Id { get; set; }
        public string Datatype { get; set; }
        public string Readonly { get; set; }

        public virtual ICollection<MenuNavigations> MenuNavigations { get; set; }
    }
}
