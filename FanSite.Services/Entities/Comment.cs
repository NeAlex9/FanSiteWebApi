using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime PublicationDate { get; set; }
        public int MediaId { get; set; }
        public int UserId { get; set; }
    }
}
