using FanSite.Services.Entities;

namespace FanSite.Services.Services
{
    public interface IMediaTypeService
    {
        Task<MediaType?> GetMediaTypeById(int id);
        Task<bool> DeleteMediaType(int id);
        Task<int> CreateMediaType(MediaType mediaType);
    }
}
