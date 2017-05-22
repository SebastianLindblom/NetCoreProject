using System;
using System.Collections.Generic;

namespace Gwenzig.Data.DataModels
{
    public partial class Banners
    {
        public int Id { get; set; }
        public int? PositionId { get; set; }
        public string BlockTextTitle { get; set; }
        public string BlockText { get; set; }
        public string BlockColor { get; set; }
        public string ImageName { get; set; }
    }
}
