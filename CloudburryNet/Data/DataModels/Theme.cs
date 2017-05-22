using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudburryNet.Data.DataModels
{
    public class Theme
    {
        [Key]
        public int? Id { get; set; }

        public string Name { get; set; }
        public string Image { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }

        public virtual ICollection<UserTheme> UserThemes { get; set; }
    }
}
