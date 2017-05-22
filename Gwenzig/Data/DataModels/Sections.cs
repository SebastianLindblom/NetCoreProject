using System;
using System.Collections.Generic;

namespace Gwenzig.Data.DataModels
{
    public partial class Sections
    {
        public int Id { get; set; }
        public string Head { get; set; }
        public string Text { get; set; }
        public int TemplateId { get; set; }
        public string BackgroundColor { get; set; }
        public string ImageName { get; set; }
        public int? PositionNumber { get; set; }
        public int? PageId { get; set; }
        public int? PagesId { get; set; }

        public virtual Pages Pages { get; set; }
    }
}
