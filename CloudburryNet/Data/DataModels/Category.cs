using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudburryNet.Data.DataModels
{
    public class Category
    {
        [Key]
        public int? Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CategoryTag> CategoryTags { get; set; }
    }
}
