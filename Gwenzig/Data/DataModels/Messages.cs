using System;
using System.Collections.Generic;

namespace Gwenzig.Data.DataModels
{
    public partial class Messages
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
        public string Fileinput { get; set; }
        public int Syncedflag { get; set; }
    }
}
