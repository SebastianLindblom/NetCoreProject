using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudburryNet.Data.DataModels
{
    public class CategoryTag
    {
        [Key]
        public int? Id { get; set; }

        public int? CategoryId { get; set; }
        public int? TagId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Tag Tag { get; set; }

    }
}
