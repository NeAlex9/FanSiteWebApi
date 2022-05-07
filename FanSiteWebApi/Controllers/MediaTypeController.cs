using FanSite.Services.Entities;
using FanSite.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace FanSiteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaTypeController : ControllerBase
    {
        private readonly IMediaTypeService _mediaTypeService;

        public MediaTypeController(IMediaTypeService mediaTypeService)
        {
            _mediaTypeService = mediaTypeService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MediaType>> GetMediaType([FromRoute] int id)
        {
            var media = await _mediaTypeService.GetMediaTypeById(id);
            if (media is null)
            {
                return NotFound();
            }
            return Ok(media);
        }

        [HttpPost]
        public async Task<ActionResult<MediaType>> CreateMediaType([FromBody] MediaType mediaType)
        {
            var id = await _mediaTypeService.CreateMediaType(mediaType);
            mediaType.Id = (byte)id;
            return this.CreatedAtAction(nameof(GetMediaType), new
            {
                id = mediaType.Id
            }, mediaType);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMediaSeries([FromRoute] byte id)
        {
            var result = await _mediaTypeService.DeleteMediaType(id);
            if (!result)
            {
                return this.NotFound();
            }

            return this.Ok();
        }
    }
}
