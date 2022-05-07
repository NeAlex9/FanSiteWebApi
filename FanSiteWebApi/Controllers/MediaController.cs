using FanSite.Services.Entities;
using FanSite.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace FanSiteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;
        private readonly IMediaPictureService _mediaPictureService;

        public MediaController(IMediaService mediaService, IMediaPictureService mediaPictureService)
        {
            _mediaService = mediaService ?? throw new ArgumentNullException(nameof(mediaService));
            _mediaPictureService = mediaPictureService ?? throw new ArgumentNullException(nameof(mediaPictureService));
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
        public async IAsyncEnumerable<Media> GetMedia([FromRoute] int offset, [FromRoute] int limit)
        { 
            await foreach (var media in _mediaService.GetMedia(offset, limit))
            {
                yield return media;
            }
        }

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
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedia([FromBody]Media media, [FromRoute]int id)
        {
            var result = await _mediaService.UpdateMedia(id, media);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpPut("{id}/picture")]
        public async Task<IActionResult> UpdateMediaPicture(int id, IFormFile formFile)
        {
            ArgumentNullException.ThrowIfNull(formFile);
            var result = await _mediaPictureService
                .UpdatePicture(id, formFile.OpenReadStream());
            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("{id}/picture")]
        public async Task<IActionResult> GetMediaPicture(int id)
        {
            var pictureBytes = await _mediaPictureService
                .GetPicture(id);
            if (pictureBytes is null)
            {
                return NotFound();
            }

            return File(pictureBytes, "image/jpg");
        }

        [HttpDelete("{id}/picture")]
        public async Task<IActionResult> DeleteMediaPicture(int id)
        {
            var result = await _mediaPictureService.DeletePicture(id);
            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
