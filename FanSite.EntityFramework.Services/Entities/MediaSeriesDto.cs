using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanSiteService.Entities
{
    public class MediaSeriesDto
    {
        public int Id { get; set; }

        public virtual ICollection<MediaDto> MediaCollection { get; set; }
    }
}
