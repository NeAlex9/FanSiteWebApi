using DomainEntities;
using FanSite.Services.Entities;
using FanSite.Services.Services.MediaSelector;

namespace FanSite.Services.Services
{
    public interface IMediaService
    {
        IAsyncEnumerable<Media> GetMedia(int offset, int limit, Query options);
        Task<Media?> GetMediaById(int id);
        Task<int> GetMediaLength(Query query);
        Task<bool> UpdateMedia(int id, Media media);
        Task<bool> DeleteMedia(int id);
        Task<int> CreateMedia(Media media);
    }
}
