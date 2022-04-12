using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanSiteService.Entities
{
    public class MediaDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public double Rating { get; set; }
        public string Role { get; set; }
    }
}
