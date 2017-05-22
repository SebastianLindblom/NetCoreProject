using System;
using System.Collections.Generic;

namespace Gwenzig.Data.DataModels
{
    public partial class Pages
    {
        public Pages()
        {
            PageMenuBinders = new HashSet<PageMenuBinders>();
            Sections = new HashSet<Sections>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Plattform { get; set; }
        public int? AuthorityLevelsId { get; set; }
        public int? AuthorityLevelsId1 { get; set; }

        public virtual ICollection<PageMenuBinders> PageMenuBinders { get; set; }
        public virtual ICollection<Sections> Sections { get; set; }
        public virtual AuthorityLevels AuthorityLevelsId1Navigation { get; set; }
    }
}
