using System;
using System.Collections.Generic;

namespace Gwenzig.Data.DataModels
{
    public partial class Prices
    {
        public Prices()
        {
            Priceattributes = new HashSet<Priceattributes>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Pricetag { get; set; }
        public string Enrollmenttext { get; set; }

        public virtual ICollection<Priceattributes> Priceattributes { get; set; }
    }
}
