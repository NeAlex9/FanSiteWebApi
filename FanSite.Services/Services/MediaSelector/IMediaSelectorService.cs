using DomainEntities;
using FanSite.Services.Entities;

namespace FanSite.Services.Services.MediaSelector
{
    public interface IMediaSelectorService
    {
        bool Verify(Media media, Query query);
    }
}
