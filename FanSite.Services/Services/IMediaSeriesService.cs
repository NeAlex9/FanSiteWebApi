using FanSite.Services.Entities;

namespace FanSite.Services.Services
{
    public interface IMediaSeriesService
    {
        Task<MediaSeries?> GetMediaSeriesById(int id);
        Task<bool> DeleteMediaSeries(int id);
        Task<int> CreateMediaSeries(MediaSeries mediaSeries);
    }
}
