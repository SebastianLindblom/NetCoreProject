﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudburryNet.Data.DataModels
{
    public class PostTag
    {
        [Key]
        public int? Id { get; set; }

        public int? PostId { get; set; }
        public int? TagId { get; set; }
        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }

    }
}
