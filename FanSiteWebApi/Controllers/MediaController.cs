using DomainEntities;
using FanSite.Services.Entities;
using FanSite.Services.Services;
using FanSite.Services.Services.MediaSelector;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Media>> GetMedia([FromRoute] int id)
        {
            var media = await _mediaService.GetMediaById(id);
            if (media is null)
            {
                return NotFound();
            }

            return Ok(media);
        }

        [HttpGet("{offset}/{limit}")]
        public async IAsyncEnumerable<Media> GetMedia([FromRoute] int offset, [FromRoute] int limit, [FromQuery] Query query)
        { 
            await foreach (var media in _mediaService.GetMedia(offset, limit, query))
            {
                yield return media;
            }
        }

        [HttpGet("length")]
        public async Task<int> GetMediaLength([FromQuery] Query query) =>
            await _mediaService.GetMediaLength(query);

        [HttpPost]
        public async Task<ActionResult<Media>> CreateMedia([FromBody] Media media)
        {
            var productId = await _mediaService.CreateMedia(media);
            media.Id = productId;
            return this.CreatedAtAction(nameof(GetMedia), new
            {
                id = media.Id
            }, media);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedia([FromRoute] byte id)
        {
            var result = await _mediaService.DeleteMedia(id);
            if (!result)
            {
                return this.NotFound();
            }

            return this.Ok();
        }
    }
}
