using System;
using System.Collections.Generic;

namespace Gwenzig.Data.DataModels
{
    public partial class FeaturedItems
    {
        public int Id { get; set; }
        public string FeaturedName { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string ImageName { get; set; }
    }
}
