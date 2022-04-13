using DomainEntities;
using FanSite.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace FanSiteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpGet("books/{offset}/{limit}")]
        public async IAsyncEnumerable<Media> GetFilms(int offset, int limit)
        {
            await foreach (var media in _mediaService
                               .GetMedia(offset, limit))
            {
                if (media.Type.Name == "Film")
                {
                    yield return media;
                }
            }
        }

    }
}
