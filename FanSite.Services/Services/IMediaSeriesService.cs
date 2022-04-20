using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities;

namespace FanSite.Services.Services
{
    public interface IMediaSeriesService
    {
        Task<MediaSeries?> GetMediaSeriesById(int id);
        Task<bool> DeleteMediaSeries(int id);
        Task<int> CreateMediaSeries(MediaSeries mediaSeries);
    }
}
