using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanSite.Services.Services.MediaSelector
{
    public class Query
    {
        public MediaTypeEnum Type { get; set; }
        public UpcomingEnum Upcoming { get; set; }
    }
}
