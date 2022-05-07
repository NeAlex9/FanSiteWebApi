using AutoMapper;
using FanSite.EntityFramework.Services.Context;
using FanSite.EntityFramework.Services.Entities;
using FanSite.Services.Entities;
using FanSite.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace FanSite.EntityFramework.Services.Services
{
    public class MediaService : IMediaService
    {
        private readonly SiteContext _context;
        private readonly IMapper _mapper;

        public MediaService(SiteContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IAsyncEnumerable<Media> GetMedia(int offset, int limit) => _context
                .Media
                .Include(media => media.Series)
                .Include(media => media.Type)
                .AsNoTracking()
                .Take(limit)
                .Skip(offset)
                .Select(dto => _mapper.Map<Media>(dto))
                .ToAsyncEnumerable();

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

        public async Task<bool> UpdateMedia(int id, Media media)
        {
            var mediaDto = await _context
                .Media
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mediaDto is null)
            {
                return false;
            }

            UpdateMedia(mediaDto, media);
            return await _context.SaveChangesAsync() > 0;
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

        private void UpdateMedia(MediaDto dto, Media media)
        {
            dto.Type.Id = media.Type.Id;
            dto.Description = media.Description;
            dto.IsUpcoming = media.IsUpcoming;
            dto.Photo = media.Photo;
            dto.PublicationDate = media.PublicationDate;
            dto.Rating = media.Rating;
            dto.Series.Id = media.Series.Id;
            dto.Title = media.Title;
        }
    }
}
