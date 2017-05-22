using System;
using System.Collections.Generic;

namespace Gwenzig.Data.DataModels
{
    public partial class Priceattributes
    {
        public int Id { get; set; }
        public string Attribute { get; set; }
        public int? PricesId { get; set; }

        public virtual Prices Prices { get; set; }
    }
}
