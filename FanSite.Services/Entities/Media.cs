using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities
{
    public class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Description { get; set; }
        public IEnumerable<byte[]> Photos { get; set; }
        public MediaType Type { get; set; }
        public double Rating { get; set; }
        public int SeriesId { get; set; }
    }
}
