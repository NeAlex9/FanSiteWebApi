using FanSite.Services.Entities;

namespace FanSite.Services.Services
{
    public interface IMediaService
    {
        IAsyncEnumerable<Media> GetMedia(int offset, int limit);
        Task<Media?> GetMediaById(int id);
        Task<bool> UpdateMedia(int id, Media media);
        Task<bool> DeleteMedia(int id);
        Task<int> CreateMedia(Media media);
    }
}
