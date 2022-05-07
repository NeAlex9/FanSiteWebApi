using AutoMapper;
using FanSite.EntityFramework.Services.Context;
using FanSite.EntityFramework.Services.Entities;
using FanSite.Services.Entities;
using FanSite.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace FanSite.EntityFramework.Services.Services
{
    public class MediaSeriesService : IMediaSeriesService
    {
        private readonly SiteContext _context;
        private readonly IMapper _mapper;

        public MediaSeriesService(SiteContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<MediaSeries?> GetMediaSeriesById(int id)
        {
            var mediaSeriesDto = await _context
                .MediaSeries
                .AsNoTracking()
                .Where(media => media.Id == id)
                .FirstOrDefaultAsync();
            if (mediaSeriesDto is null)
            {
                return null;
            }

            return _mapper.Map<MediaSeries>(mediaSeriesDto);
        }

        public async Task<bool> DeleteMediaSeries(int id)
        {
            var series = await _context
                .MediaSeries
                .Where(type => type.Id == id)
                .FirstOrDefaultAsync();

            if (series is null)
            {
                return false;
            }

            _context.MediaSeries.Remove(series);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> CreateMediaSeries(MediaSeries mediaSeries)
        {
            if (mediaSeries is null)
            {
                throw new ArgumentNullException(nameof(mediaSeries));
            }

            var dto = _mapper.Map<MediaSeriesDto>(mediaSeries);
            await _context.MediaSeries.AddAsync(dto);
            await _context.SaveChangesAsync();
            return dto.Id;
        }
    }
}
