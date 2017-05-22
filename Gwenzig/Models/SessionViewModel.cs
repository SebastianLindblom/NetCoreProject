using Gwenzig.Data.DataModels;
using System.Collections.Generic;

namespace Gwenzig.Models
{
    public class SessionViewModel
    {
        public SessionViewModel()
        {

        }
        public IEnumerable<Banners> Banner { get; set; }
        public IEnumerable<Businessareas> Businessareas { get; set; }
        public IEnumerable<FeaturedItems> FeaturedItems { get; set; }
        public IEnumerable<Messages> Messages{ get; set; }
        public IEnumerable<Prices> Prices { get; set; }
        public IEnumerable<Sections> Sections{ get; set; }
        public IEnumerable<Serviceareas> Serviceareas{ get; set; }
        public IEnumerable<Serviceoffers> Serviceoffers { get; set; }
        public IEnumerable<ShowcaseItems> ShowcaseItems { get; set; }
    }
}