using DomainEntities;

namespace FanSite.Services.Services
{
    public interface IMediaService
    {
        IAsyncEnumerable<Media> GetMedia(int offset, int limit);
        Task<Media> GetMediaById(int id);
        Task<int> GetMediaLength();
        Task<bool> UpdateMedia(int id, Media media);
        Task<bool> DeleteMedia(int id);
        Task<Media> CreateMedia(Media media);
    }
}
