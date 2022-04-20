using AutoMapper;
using FanSite.EntityFramework.Services.Entities;
using FanSite.Services.Entities;
using FanSite.Services.Services;
using FanSite.Services.Services.MediaSelector;
using FanSiteService.Context;
using Microsoft.EntityFrameworkCore;

namespace FanSite.EntityFramework.Services.Services
{
    public class MediaService : IMediaService
    {
        private readonly SiteContext _context;
        private readonly IMapper _mapper;
        private readonly IMediaSelectorService _mediaSelectorService;

        public MediaService(SiteContext context, IMapper mapper, IMediaSelectorService mediaSelectorService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediaSelectorService = mediaSelectorService ?? throw new ArgumentNullException(nameof(mediaSelectorService));
        }

        public async IAsyncEnumerable<Media> GetMedia(int offset, int limit, Query query)
        {
            await foreach (var media in _context
                               .Media
                               .Include(media => media.Series)
                               .Include(media => media.Type)
                               .AsNoTracking()
                               .AsEnumerable()
                               .Where(media => _mediaSelectorService.Verify(_mapper.Map<Media>(media), query))
                               .Take(limit)
                               .Skip(offset)
                               .ToAsyncEnumerable())
            {
                yield return _mapper.Map<Media>(media);
            }
        }

        public async Task<Media?> GetMediaById(int id)
        {
            var mediaDto = await _context
                .Media
                .Include(media => media.Type)
                .Include(media => media.Series)
                .AsNoTracking()
                .Where(media => media.Id == id)
                .FirstOrDefaultAsync();
            if (mediaDto is null)
            {
                return null;
            }

            return _mapper.Map<Media>(mediaDto);
        }

        public async Task<int> GetMediaLength(Query query) =>
            await _context
                .Media
                .Where(media => _mediaSelectorService.Verify(_mapper.Map<Media>(media), query))
                .AsNoTracking()
                .CountAsync();

        public Task<bool> UpdateMedia(int id, Media media)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteMedia(int id)
        {
            var media = await _context
                .Media
                .Where(media => media.Id == id)
                .FirstOrDefaultAsync();
            if (media is null)
            {
                return false;
            }

            _context.Media.Remove(media);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> CreateMedia(Media media)
        {
            if (media is null)
            {
                throw new ArgumentNullException(nameof(media));
            }

            var mediaTypeDto = await _context
                .MediaTypes
                .FirstOrDefaultAsync(type => type.Id == media.Type.Id);
            if (mediaTypeDto is null)
            {
                return -1;
            }

            var mediaSeriesDto = await _context
                .MediaSeries
                .FirstOrDefaultAsync(series => series.Id == media.Series.Id);
            if (mediaSeriesDto is null)
            {
                return -1;
            }

            var dto = _mapper.Map<MediaDto>(media);
            dto.Type = mediaTypeDto;
            dto.Series = mediaSeriesDto;
            await _context.Media.AddAsync(dto);
            await _context.SaveChangesAsync();
            return dto.Id;
        }
    }
}
