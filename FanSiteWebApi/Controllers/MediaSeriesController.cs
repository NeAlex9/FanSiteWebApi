using FanSite.Services.Entities;
using FanSite.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace FanSiteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaSeriesController : ControllerBase
    {
        private readonly IMediaSeriesService _mediaSeriesService;

        public MediaSeriesController(IMediaSeriesService mediaSeriesService)
        {
            _mediaSeriesService = mediaSeriesService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MediaSeries>> GetMediaSeries([FromRoute] int id)
        {
            var media = await _mediaSeriesService.GetMediaSeriesById(id);
            if (media is null)
            {
                return NotFound();
            }

            return Ok(media);
        }

        [HttpPost]
        public async Task<ActionResult<MediaType>> CreateMediaSeries([FromBody] MediaSeries mediaSeries)
        {
            var id = await _mediaSeriesService.CreateMediaSeries(mediaSeries);
            mediaSeries.Id = (byte)id;
            return this.CreatedAtAction(nameof(GetMediaSeries), new
            {
                id = mediaSeries.Id
            }, mediaSeries);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMediaSeries([FromRoute] byte id)
        {
            var result = await _mediaSeriesService.DeleteMediaSeries(id);
            if (!result)
            {
                return this.NotFound();
            }

            return this.Ok();
        }
    }

}
