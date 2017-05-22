using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudburryNet.Data.DataModels
{
    public class UserTheme
    {
        [Key]
        public int? Id { get; set; }
        
        public int? ThemeId { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Theme Theme { get; set; }
    }
}
