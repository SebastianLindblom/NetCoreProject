using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudburryNet.Data.DataModels
{
    public class UserCategory
    {
        [Key]
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }

        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
    }
}
