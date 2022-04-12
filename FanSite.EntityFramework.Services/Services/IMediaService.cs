using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities;

namespace FanSite.EntityFramework.Services.Services
{
    public interface IMediaService
    {
        IAsyncEnumerable<Media> GetBooks();
        IAsyncEnumerable<Media> GetFilms();
        Task<Media> GetMediaById(int id);
        Task<int> GetBooksLength();
        Task<int> GetFilmsLength();
        Task<bool> UpdateMedia(int id, Media media);
        Task<bool> DeleteMedia(int id);
        Task<Media> CreateMedia(Media media);
    }
}
